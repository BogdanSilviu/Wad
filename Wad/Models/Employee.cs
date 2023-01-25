﻿namespace Wad.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}
