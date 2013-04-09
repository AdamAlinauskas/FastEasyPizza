using System.Web.Mvc;
using Dto;
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
