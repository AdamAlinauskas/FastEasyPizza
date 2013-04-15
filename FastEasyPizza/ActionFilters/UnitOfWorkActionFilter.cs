using System.Web.Mvc;
using Service;

namespace FastEasyPizza.ActionFilters
{
    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        private IUnitOfWork unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            unitOfWork.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            unitOfWork.End();

        }
    }
}