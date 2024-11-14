using CarPark.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.User.Controllers
{
    [Authorize (Roles = "admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult GetEmployeeByAge()
        {
            var result = _employeeService.GetEmployeesByAge();

            return View(result.Result); 
        }

    }
}
