using CarPark.Business.Abstract;
using CarPark.Entities.Concrete;
using CarPark.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPark.Core.Models;
using CarPark.Models.ViewModels.Employee;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using AspNetCore.Identity.MongoDbCore.Models;

namespace CarPark.Business.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;
        private readonly RoleManager<MongoIdentityRole> _roleManager;

        public EmployeeService(IEmployeeDataAccess employeeDataAccess, RoleManager<MongoIdentityRole> roleManager) 
        {
            _employeeDataAccess = employeeDataAccess;
            _roleManager = roleManager;
        }

        public async Task<GetOneResult<EmployeeMainRole>> GetEmployeeRolesAsync(string id)
        {
            var result = new GetOneResult<EmployeeMainRole>();

            try
            {
                var roles = _roleManager.Roles != null ? _roleManager.Roles.ToList() : null;

                var employee = await _employeeDataAccess.GetByIdAsync(id, "guid");

                var employeeRoles = employee != null && employee.Entity != null
                    && employee.Entity.Roles != null ?
                    employee.Entity.Roles.Select(x => new EmployeeRoles
                    {
                        Id = x.ToString(),
                        Name = roles.FirstOrDefault(y => y.Id == x).Name,
                    }).ToList() : null;

                result.Entity = new EmployeeMainRole
                {
                    Roles = roles,
                    EmployeeRoleList = employeeRoles
                };
            result.Success = true;
            }
            catch (Exception ex) 
            {
                result.Entity = null;
                result.Success = false;
            }
            

            return result;
        }

        public GetManyResult<Employee> GetEmployees()
        {
            var employeeList = _employeeDataAccess.GetAll();

            return employeeList;
        }


        public async Task<GetOneResult<Employee>> UpdateEmployeeRolesAsync(string employeeId, string[] employeeRoleList)
        {
            var employee = await _employeeDataAccess.GetByIdAsync(employeeId, "guid");

            var roles = employeeRoleList.Select(x=> new Guid(x)).ToList();

            employee.Entity.Roles = null;
            employee.Entity.Roles = roles;

            var result = await _employeeDataAccess.ReplaceOneAsync(employee.Entity, employeeId, "guid");
            result.Message = $"{employee.Entity.Name} {employee.Entity.SurName} adlı kullanıcın rol güncellemesi başarılı bir şekilde gerçekleşti.";
            return result;
        }
    }
}
