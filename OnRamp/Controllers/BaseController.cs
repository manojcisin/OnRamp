
using System;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;

using System.Web;
using OnRamp.Helpers;

namespace Volt.Web.Dashboard.Controllers
{
    /// <summary>
    /// this is basecontroller all controller inherite from this
    /// </summary>
    public abstract class BaseController : Controller
    {
        //private readonly VoltUserFacade _voltUserFacade;
        //private readonly Mapper<Person, PersonDetailModel> _personMapper = new Mapper<Person, PersonDetailModel>();

        protected BaseController()
        {
           
        }

        /// <summary>
        /// this will call at every Action of controller
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

			if (User.Identity.IsAuthenticated && SessionManager.Instance.CurrentUser == null) {
				var email = User.Identity is FormsIdentity ? User.Identity.Name :
						(User.Identity as ClaimsIdentity).FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value;
				//var user = _voltUserFacade.GetUserByEmail(email);
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