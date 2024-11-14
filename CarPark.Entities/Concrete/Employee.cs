using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    [CollectionName("Employee")]
    public class Employee : MongoIdentityUser
    {
        public Employee() 
        {
            CreatedDate = DateTime.Now;
            Status = 1;
        }
        public EmployeeContact EmployeeContact { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public short Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


    }
}
