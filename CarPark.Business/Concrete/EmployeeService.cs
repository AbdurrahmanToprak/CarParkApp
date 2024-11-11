using CarPark.Business.Abstract;
using CarPark.Entities.Concrete;
using CarPark.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPark.Core.Models;

namespace CarPark.Business.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;

        public EmployeeService(IEmployeeDataAccess employeeDataAccess)
        {
            _employeeDataAccess = employeeDataAccess;
        }

        public GetManyResult<Employee> GetEmployeesByAge()
        {
            var employeeList = _employeeDataAccess.GetAll();

            return employeeList;
        }
    }
}
