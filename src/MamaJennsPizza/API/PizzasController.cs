using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MamaJennsPizza.Services;
using Microsoft.AspNetCore.Authorization;
using MamaJennsPizza.Services.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MamaJennsPizza.API
{
    [Route("api/[controller]")]
    public class PizzasController : Controller
    {
        private PizzaService _pService;
        public PizzasController(PizzaService ps)
        {
            _pService = ps;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<PizzaDTO> GetThemPizzas()
        {
            return _pService.GetPizzasForUser(User.Identity.Name);
        }

        //this will return /api/pizzas/someId
        [HttpGet("{id}")]
        public PizzaDTO GetPizzaById(int id)
        {
            return _pService.GetPizzaById(id, User.Identity.Name);
        }

        //posting a pizza
        [HttpPost]
        public IActionResult PostPizza([FromBody] PizzaDTO pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pService.PostPizza(pizza, User.Identity.Name);

            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult EditPizza([FromBody] PizzaDTO pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pService.PostPizza(pizza, User.Identity.Name);

            return Ok();
        }

        //delete a pizza
        [HttpDelete("{id}")]
        public IActionResult DeletePizza(PizzaDTO pizza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pService.DeletePizza(pizza, User.Identity.Name);

            return Ok();
        }

    }
}
