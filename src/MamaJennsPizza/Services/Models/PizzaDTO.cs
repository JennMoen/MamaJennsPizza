﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamaJennsPizza.Services.Models
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Toppings { get; set; }
        public decimal Price { get; set; }


    }
}
