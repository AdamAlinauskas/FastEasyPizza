using System.Web.Mvc;
using DataAccess;
using Dto;
using NHibernate;
using Service;

namespace FastEasyPizza.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderTask orderTask;

        public OrderController()
        {
        }

        public OrderController(IOrderTask orderTask)
        {
            this.orderTask = orderTask;
        }

        public ActionResult Index()
        {
            var sessionFactory = new DatabaseSessionFactory();
            var session = sessionFactory.Create();

            return View(new OrderDto());
        }

        [HttpPost]
        public ActionResult Index(OrderDto dto)
        {
            orderTask.ProcessOrder(dto);
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
