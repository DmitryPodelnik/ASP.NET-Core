using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Model_04._05._21.Models
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }

        public Address() { }

        public Address(string city, string street, string house) 
        {
            City = city;
            Street = street;
            House = house;
        }

        public override string ToString()
        {
            return City + " " + Street + " " + House;
        }
    }
}
