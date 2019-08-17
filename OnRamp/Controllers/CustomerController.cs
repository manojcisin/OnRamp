using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnRamp.Controllers {
	public class CustomerController : BaseController {
		private readonly IRepositoryCustomerBL iRepositoryCustomerBL;

		public CustomerController(IRepositoryCustomerBL repositoryCustomerBL) {
			iRepositoryCustomerBL = repositoryCustomerBL;
		}

		// GET: Customer
		public ActionResult Index() {
			return View();
		}

		public ActionResult Add() {
			return View();
		}

		public ActionResult AddCustomer(Customers customers) {
			Customers result = iRepositoryCustomerBL.AddCustomer(customers);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetList() {
			List<Customers> customers = iRepositoryCustomerBL.GetCusotmerList();
			return Json(customers, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Edit(int id) {
			Customers customer = iRepositoryCustomerBL.GetCustomerById(id);
			var serializer = new JavaScriptSerializer();
			ViewBag.customer = serializer.Serialize(customer);
			return View();
		}

		public ActionResult Update(Customers customer) {
			Customers result = iRepositoryCustomerBL.UpdateCustomer(customer);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Delete(int id) {
			bool result = iRepositoryCustomerBL.RemoveCustomer(id);
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}