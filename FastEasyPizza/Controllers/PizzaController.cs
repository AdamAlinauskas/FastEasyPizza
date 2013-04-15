using System.Web.Mvc;
using Dto;
using FastEasyPizza.ActionFilters;
using Service;

namespace FastEasyPizza.Controllers
{
    [UnitOfWorkActionFilter]
    public class PizzaController : Controller
    {
        private readonly IPizzaQuery pizzaQuery;
        private readonly IAddPizzaCommand addPizzaCommand;

        public PizzaController(IPizzaQuery pizzaQuery,IAddPizzaCommand addPizzaCommand)
        {
            this.pizzaQuery = pizzaQuery;
            this.addPizzaCommand = addPizzaCommand;
        }

        public ViewResult Index()
        {
            return View(pizzaQuery.AllPizzas());
        }

        public ViewResult AddEditPizza()
        {
            return View(new PizzaDto());
        }

        [HttpPost]
        public RedirectToRouteResult AddEditPizza(PizzaDto dto)
        {
            addPizzaCommand.Execute(dto);
            return RedirectToAction("Index");
        }
    }
}