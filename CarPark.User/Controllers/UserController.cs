using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CarPark.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _stringLocalizer;
        private readonly IRepository<Employee> _employeeRepository;

        public UserController (IStringLocalizer<UserController> stringLocalizer, IRepository<Employee> employeeRepository)
        {
            _stringLocalizer = stringLocalizer;
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var name_surname_value = _stringLocalizer["Name_Surname"];
            return View();
        }

        public IActionResult Create()
        {
            //var result = _employeeRepository.InsertOne(new Employee
            //{
            //    Email = "toprak@gmail.com",
            //    Password = "12345",
            //    CreatedDate = DateTime.Now,
            //    UserName = "Toprak",
            //});
            //var result2 = _employeeRepository.InsertOneAsync(new Employee
            //{
            //    Email = "toprak1111@gmail.com",
            //    Password = "123456",
            //    CreatedDate = DateTime.Now,
            //    UserName = "Toprak1111",
            //});

            //var result3 = _employeeRepository.InsertMany(new List<Employee>
            //{ new Employee
            //{
            //    Email = "toprak@gmail.com",
            //    Password = "12345",
            //    CreatedDate = DateTime.Now,
            //    UserName = "Toprak",
            //},
            //new Employee
            //{
            //     Email = "toprak@gmail.com",
            //    Password = "12345",
            //    CreatedDate = DateTime.Now,
            //    UserName = "Toprak",
            //}
            //});

            var result4 = _employeeRepository.AsQueryable();

            var result5 = _employeeRepository.GetById("672fdc85ae1e737c8f8fc54a");

            var result6 = _employeeRepository.DeleteOne(x => x.Email.Contains("111"));

            var result7 = _employeeRepository.ReplaceOne(new Employee
            {
                Email = "abdurrahmantoprak@gmail.com",
                Password = "123456789",
                CreatedDate = DateTime.Now,
                UserName = "Toprak23",
            }, "672fdc85ae1e737c8f8fc54a");

                
               













            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateRequestModel requestModel)
        {
            return View(requestModel);
        }
    }
}
