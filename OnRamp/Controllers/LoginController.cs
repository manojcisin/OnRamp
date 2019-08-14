using System.Web.Mvc;

namespace OnRamp.Controllers {
	public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }



		//[HttpPost]
		//[AllowAnonymous]
		//[OutputCache(NoStore = true, Duration = 0)]
		//public ActionResult Login(PersonDetailModel obj) {
		//	var excludedDomains = ConfigurationManager.AppSettings["SsoDomains"].ToString().Split(new char[] { ',' });
		//	if (excludedDomains.Any(x => !String.IsNullOrWhiteSpace(x) && obj.Email1.ToLower().EndsWith(x)))
		//		return RedirectPermanent("/SsoLogin/Login?attemptId=" + Guid.NewGuid().ToString());
		//	//return RedirectToAction("Login", "SsoLogin", new { attemptId = Guid.NewGuid().ToString() });

		//	var user = _voltUserFacade.Login(obj.Email1, obj.Password);

		//	if (user != null) {
		//		if (!(user.PasswordExp > DateTime.Now)) {
		//			ViewBag.isPassExp = true;
		//			ViewBag.message = "Your Password has expired.";
		//			return View(obj);
		//		}
		//		else {
		//			if (user.PasswordExp != null && ((user.PasswordExp - DateTime.Now).Value.Days <= 10))
		//				SessionManager.Instance.IsPassExpire10Days = true;
		//		}
		//		var account = _accountFacade.GetByID(user.AccountId.GetValueOrDefault());
		//		if (user.StatusID == (int)EStatus.Pending || account.StatusID == (int)EStatus.Pending) {
		//			//when user status is pending means statusId = 2
		//			ViewBag.message = "User account is pending approval.";
		//			return View(obj);
		//		}
		//		if (user.StatusID == (int)EStatus.Inactive || account.StatusID == (int)EStatus.Inactive) {
		//			ViewBag.message = "User account has been deactivated.";
		//			return View(obj);
		//		}

		//		// Gets the cookie
		//		FormsAuthentication.SetAuthCookie(obj.Email1, true);
		//		SessionManager.Instance.CurrentUser = user;
		//		SessionManager.Instance.AuthToken = TokenStore.GetToken(user.Email1);

		//		if (user.RolesID == null)
		//			return RedirectToAction("menu", "system");
		//		if (user.ReadEula == null)
		//			return RedirectToAction("eula");
		//		if (string.IsNullOrWhiteSpace(user.PImageURL) && user.RolesID == (int)ERoles.FieldEmployee)
		//			return RedirectToAction("EditBadge", "Person");
		//		if (user.RolesID == (int)ERoles.SystemAdministrator)
		//			return RedirectToAction("AccountList", "Account");

		//		if (user.RolesID == (int)ERoles.FieldEmployee) return Redirect(ConfigurationManager.AppSettings["BaseURL"] + "/credo");

		//		var returnUrl = Request.Form["hdnreturnUrl"];
		//		if (Url.IsLocalUrl(returnUrl))
		//			return Redirect(returnUrl);
		//		return RedirectToAction("index", "system");
		//	}
		//	//If we got this far, something failed, redisplay form
		//	ViewBag.errormessage = "Username or Password incorrect";
		//	return View(obj);
		//}

		//public ActionResult LogOut() {
		//	if (!Request.QueryString.HasKeys())
		//		LogOutUser();
		//	Session["Confirm"] = TempData["Confirm"];
		//	TempData["Confirm"] = string.Empty;

		//	return RedirectToAction("Login", "Person");
		//}

		//private void LogOutUser() {
		//	Response.Cookies.Clear();
		//	Response.Cookies.Remove(".AspNet.Cookies");
		//	Response.Cookies.Remove("ASP.NET_SessionId");
		//	if (Request.Cookies[".AspNet.Cookies"] != null) {
		//		HttpCookie myCookie = new HttpCookie(".AspNet.Cookies");
		//		myCookie.Expires = DateTime.Now.AddDays(-1d);
		//		Response.Cookies.Add(myCookie);
		//	}
		//	if (Request.Cookies["ASP.NET_SessionId"] != null) {
		//		HttpCookie myCookie = new HttpCookie("ASP.NET_SessionId");
		//		myCookie.Expires = DateTime.Now.AddDays(-1d);
		//		Response.Cookies.Add(myCookie);
		//	}
		//	Session.Clear();
		//	Session.Abandon();
		//	FormsAuthentication.SignOut();
		//	HttpContext.User = null;
		//	//HttpContext.GetOwinContext().Authentication.SignOut(
		//	//    OpenIdConnectAuthenticationDefaults.AuthenticationType);
		//}




	}
}