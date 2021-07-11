using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
