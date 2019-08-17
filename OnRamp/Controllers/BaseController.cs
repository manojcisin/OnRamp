
using System;
using System.Web.Mvc;
using OnRamp.Helpers;

namespace OnRamp.Controllers {
	/// <summary>
	/// this is basecontroller all controller inherite from this
	/// </summary>
	public abstract class BaseController : Controller
    {
        protected BaseController()
        {
           
        }

        /// <summary>
        /// this will call at every Action of controller
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

			if (SessionManager.Instance.CurrentUser == null) {

				filterContext.Result = new ViewResult {
					ViewName = "UnAuthorized",
				
				};
				
			}
		}

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException("filterContext");
			if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled) 
				return;

				filterContext.ExceptionHandled = true;
				filterContext.Result = new ViewResult { ViewName = "Error" };
			}
        }
    }
