using System.Web.Mvc;
using Domain;
using Dto;
using FastEasyPizza.ActionFilters;
using Service;

namespace FastEasyPizza.Controllers
{
    [UnitOfWorkActionFilter]
    public class PizzaController : Controller
    {
        private readonly IPizzaQuery pizzaQuery;

        public PizzaController(IPizzaQuery pizzaQuery)
        {
            this.pizzaQuery = pizzaQuery;
        }

        public ViewResult Index()
        {
            return View(pizzaQuery.AllPizzas());
        }
    }
}