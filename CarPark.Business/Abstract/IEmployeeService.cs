using CarPark.Core.Models;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPark.Models.ViewModels.Employee;

namespace CarPark.Business.Abstract
{
    public interface IEmployeeService
    {
        GetManyResult<Employee> GetEmployees();
        Task<GetOneResult<EmployeeMainRole>> GetEmployeeRolesAsync(string id);
        Task<GetOneResult<Employee>> UpdateEmployeeRolesAsync(string employeeId, string[] employeeRoleList);

    }
}
