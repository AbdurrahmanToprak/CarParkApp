﻿using CarPark.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Models.ViewModels.Employee
{
    public class EmployeeProfileInfo 
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public bool ReceiveNotification { get; set; }
        public string ReceiveMessage { get; set; }
        public IFormFile Image {get; set;}
        public string ImageUrl { get; set; }
        public IEnumerable<City> Cities { get; set; } 
    }
}
