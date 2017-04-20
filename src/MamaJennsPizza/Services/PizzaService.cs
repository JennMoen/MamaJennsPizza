using MamaJennsPizza.Infrastructure;
using MamaJennsPizza.Models;
using MamaJennsPizza.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamaJennsPizza.Services
{
    public class PizzaService
    {
        private PizzaRepository _pRepo;
        private UserRepository _uRepo;

        public PizzaService(PizzaRepository pr, UserRepository ur)
        {
            _pRepo = pr;
            _uRepo = ur;
        }

        //get a list of pizzaDTO for the logged in user
        public IList<PizzaDTO> GetPizzasForUser(string userName)
        {
            return (from p in _pRepo.GetPizzasForUser(userName)
                    select new PizzaDTO()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Toppings = p.Toppings

                    }).ToList();
        }

        //service method for getting a single pizzaDTO back
        public PizzaDTO GetPizzaById(int id, string userName)
        {
            return (from p in _pRepo.GetPizzaById(id, userName)
                    select new PizzaDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Toppings = p.Toppings
                    }).FirstOrDefault();
        }

        //editing or posting a new pizza
        public void PostPizza(PizzaDTO pizza, string user)
        {
            if (pizza.Id == 0)
            {
                Pizza dbPizza = new Pizza()
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Toppings = pizza.Toppings,
                    Price = pizza.Price,
                    UserId = _uRepo.GetUser(user).First().Id
                };
                _pRepo.AddPizza(dbPizza, user);
            }
            else
            {
                Pizza dbPizza = _pRepo.GetPizzaById(pizza.Id, user).FirstOrDefault();

                dbPizza.Name = pizza.Name;
                dbPizza.Price = pizza.Price;
                dbPizza.Toppings = pizza.Toppings;

                _pRepo.EditPizza();
            }
        }

        //deleting a pizza
        public void DeletePizza(PizzaDTO pizza, string user)
        {
            _pRepo.DeletePizza(_pRepo.GetPizzaById(pizza.Id, user).First(), user);
        }
    }
}
