﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Net;

namespace CarPark.User.Models
{
    public class Test
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public string NameSurname { get; set; }

        public int Age { get; set; } 

        public ICollection<Address> AddressList { get; set; }  
    }

    public class Address
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
