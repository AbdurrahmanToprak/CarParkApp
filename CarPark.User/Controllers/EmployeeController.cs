using AutoMapper;
using CarPark.Business.Abstract;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModels.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.User.Controllers
{
    [Authorize (Roles = "admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly IWebHostEnvironment _env;


        public EmployeeController(IEmployeeService employeeService, UserManager<Employee> userManager, ICityService cityService, IMapper mapper, IWebHostEnvironment env)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _cityService = cityService;
            _mapper = mapper;
            _env = env;
        }

        public IActionResult GetEmployeeByAge()
        {
            var result = _employeeService.GetEmployeesByAge();

            return View(result.Result); 
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            var cities = await _cityService.GetAllCitiesAsync();
            user.ImageUrl = $"Media/Employees/{user.ImageUrl}";
            var employeeInfo = _mapper.Map<EmployeeProfileInfo>(user);
            employeeInfo.Cities = cities.Result;
            return View(employeeInfo);
        }
        [HttpPost]
        public async Task<IActionResult> Settings(EmployeeProfileInfo employeeInfo)
        {
            var user = _userManager.GetUserAsync(User).Result;
            string imgUrl = "";
            if(employeeInfo.Image != null && employeeInfo.Image.Length > 0)
            {
                var path = Path.Combine(_env.WebRootPath, "Media/Employees/");
                var fileName = Guid.NewGuid().ToString() + " " + employeeInfo.Image.FileName;

                var filePath = Path.Combine(path, fileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
					employeeInfo.Image.CopyTo(fileStream);
                    imgUrl = fileName;
                }
            }
            else
            {
                imgUrl = user.ImageUrl;
            }
			employeeInfo.UserName = user.UserName;
			employeeInfo.Email = user.Email;
			employeeInfo.ImageUrl = user.ImageUrl;

            var employee = _mapper.Map(employeeInfo, user);
            var updated = await _userManager.UpdateAsync(employee);
            if(updated.Succeeded)
            {
                return Json(new { message = "Başarılı", success = true, employee = employee });
            }
            else
            {
				return Json(new { message = "Başarısız", success = false });
			}
        }
    }
}
