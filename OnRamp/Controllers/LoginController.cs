using OnRamp.Helpers;
using OnRamp.Model.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnRamp.Controllers {
	public class LoginController : Controller
    {
        // GET: Login
		[HttpGet]
        public ActionResult Login()
        {
            return View();
        }



		[HttpPost]
		[AllowAnonymous]
		[OutputCache(NoStore = true, Duration = 0)]
		public ActionResult Login(User model) {


			var user = model.Email == "ashish@gmail.com" && model.Password == "ashish123" ? true : false;

			if (user) {

				// Gets the cookie
				FormsAuthentication.SetAuthCookie(model.Email, true);
				SessionManager.Instance.CurrentUser = model;
		//		SessionManager.Instance.AuthToken = TokenStore.GetToken(model.UserName);

				return RedirectToAction("index", "home");
			}
			//If we got this far, something failed, redisplay form
			ViewBag.errormessage = "Username or Password incorrect";
			return View(model);
		}

		public ActionResult LogOut() {
			if (!Request.QueryString.HasKeys())
				LogOutUser();
			Session["Confirm"] = TempData["Confirm"];
			TempData["Confirm"] = string.Empty;

			return RedirectToAction("Login", "Login");
		}

		private void LogOutUser() {
			Response.Cookies.Clear();
			Session.Clear();
			Session.Abandon();
			FormsAuthentication.SignOut();
			HttpContext.User = null;
			//HttpContext.GetOwinContext().Authentication.SignOut(
			//    OpenIdConnectAuthenticationDefaults.AuthenticationType);
		}




	}
}