
using System;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
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
				//var email = User.Identity is FormsIdentity ? User.Identity.Name :
				//		(User.Identity as ClaimsIdentity).FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;

				filterContext.Result = new ViewResult {
					ViewName = "UnAuthorized",
				
				};
				//var user = _service.GetUserByEmail(email);
				//if (user != null) {
				//	var person = _personMapper.FromModel(user);

				//	SessionManager.Instance.CurrentUser = person;
				//}
				//else {
				//	RedirectToAction("Index", "Login");
				//}
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