using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamaJennsPizza.Services.Models
{
    public class UserDTO
    {
        public string Name { get; set; }

        public IList<PizzaDTO> MyPizzas { get; set; }


    }
}
