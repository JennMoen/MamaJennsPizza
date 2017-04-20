using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MamaJennsPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Toppings { get; set; }
        public decimal Price { get; set; }

        //can explicitly declare foreign keys if needed
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
