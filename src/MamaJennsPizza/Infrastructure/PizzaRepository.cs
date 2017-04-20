using MamaJennsPizza.Data;
using MamaJennsPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamaJennsPizza.Infrastructure
{
    public class PizzaRepository
    {
        //don't forget dependency injection
        private ApplicationDbContext _db;

        public PizzaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //query to get a list of the logged in user's pizza
        public IQueryable<Pizza> GetPizzasForUser(string userName)
        {
            return from p in _db.Pizzas
                   where p.User.UserName == userName
                   select p;
        }

        //query to get a single from the database by its id
        public IQueryable<Pizza> GetPizzaById(int id, string userName)
        {
            return from p in _db.Pizzas
                   where p.Id == id && p.User.UserName == userName
                   select p;
        }

        //adding a pizza
        public void AddPizza(Pizza pizza, string user)
        {
            _db.Pizzas.Add(pizza);
            _db.SaveChanges();
        }

        //editing a pizza
        public void EditPizza()
        {
            _db.SaveChanges();
        }

        //deleting a pizza
        public void DeletePizza(Pizza pizza, string userName)
        {
            _db.Pizzas.Remove(pizza);
            _db.SaveChanges();
        }
    }
}
