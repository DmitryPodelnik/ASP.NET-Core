using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Model_04._05._21.Models
{
    public class OrdersRepository
    {
        public List<Order> Orders { get; set; } = new();

        public OrdersRepository()
        {
            Orders.Add(
                new Order(
                    "First", 
                    5, 
                    new Address("Odesa", "The Central Street", "24A"),
                    "For mother",
                    "Alex", 
                    DateTime.Now
                    )
                );
            Orders.Add(
               new Order(
                   "Second",
                   3,
                   new Address("Lviv", "The Central Street", "22B"),
                   "For father",
                   "Michael",
                   DateTime.Now
                   )
               );
            Orders.Add(
               new Order(
                   "Third",
                   1,
                   new Address("Kyiv", "The Central Street", "18C"),
                   "For brother",
                   "Tom",
                   DateTime.Now
                   )
               );
            Orders.Add(
               new Order(
                   "Fourth",
                   7,
                   new Address("Kharkiv", "The Central Street", "2A"),
                   "For sister",
                   "Edward",
                   DateTime.Now
                   )
               );
            Orders.Add(
               new Order(
                   "Fifth",
                   3,
                   new Address("Mykolayiv", "The Central Street", "29B"),
                   "For husband",
                   "Paul",
                   DateTime.Now
                   )
               );
        }
    }
}
