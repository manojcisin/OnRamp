using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnRamp.Controllers {
	public class OrderController : BaseController {

		private readonly IRepositoryOrderBL iRepositoryOrderBL;

		public OrderController(IRepositoryOrderBL repositoryOrderBL) {
			iRepositoryOrderBL = repositoryOrderBL;
		}

		// GET: Order
		public ActionResult Index() {
			return View();
		}

		public JsonResult GetList() {
			List<Orders> orders = iRepositoryOrderBL.GetOrderList();
			return Json(orders, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetOrderForMonth() {
			var result = iRepositoryOrderBL.GetOrderForMonth();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetOutstandingPayments() {
			var result = iRepositoryOrderBL.GetOutstandingPayments();
			return Json(result, JsonRequestBehavior.AllowGet);
		}


	}
}