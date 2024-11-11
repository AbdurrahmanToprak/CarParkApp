using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Localization;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using CarPark.Entities.Concrete;
using JsonConvert = Newtonsoft.Json.JsonConvert;


namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly MongoClient client;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
           // client = new MongoClient("mongodb+srv://toprak23:toprak2323@carparkcluster.hb7bu.mongodb.net/test?retryWrites=true&w=majority&ssl=true");


        }

        public IActionResult Index()
        {
            //var database = client.GetDatabase("CarParkDB");

            //var jsonString = System.IO.File.ReadAllText("cities.json");

            //var cities = JsonConvert.DeserializeObject<List<cities>>(jsonString);

            //var citiesCollection = database.GetCollection<City>("City");

          
            //    foreach (var item in cities)
            //    {
            //        var city = new City()
            //        {
            //            Id = ObjectId.GenerateNewId(),
            //            Name = item.name,
            //            Plate = item.plate,
            //            Latitude = item.latitude,
            //            Longitude = item.longitude,
            //            Counties = new List<County>()
            //        };
            //        foreach (var item2 in item.counties)
            //        {
            //            city.Counties.Add(new County
            //            {
            //                Id = ObjectId.GenerateNewId(),
            //                Name = item2,
            //                Latitude = "",
            //                Longitude = "",
            //                PostCode = ""
            //            });
            //        }

            //        citiesCollection.InsertOne(city);
            //    }

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}

