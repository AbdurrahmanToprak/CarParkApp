using AspNetCore.Identity.MongoDbCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Models.ViewModels.Employee
{
    public class EmployeeMainRole
    {
        public List<MongoIdentityRole> Roles { get; set; }  
        public List<EmployeeRoles> EmployeeRoleList { get; set; }
    }
    public class EmployeeRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
