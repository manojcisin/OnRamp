using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

		
	}
}