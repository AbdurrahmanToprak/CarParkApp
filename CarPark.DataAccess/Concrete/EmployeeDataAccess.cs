using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Context;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DataAccess.Concrete
{
    public class EmployeeDataAccess : MongoRepositoryBase<Employee>, IEmployeeDataAccess
    {
        private readonly MongoDBContext _context;
        private readonly IMongoCollection<Employee> _employeeCollection;
        public EmployeeDataAccess(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDBContext(settings);
            _employeeCollection = _context.GetMongoCollection<Employee>();
        }
    }
}
