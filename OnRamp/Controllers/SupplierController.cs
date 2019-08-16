using OnRamp.BusinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnRamp.Model.Models;

namespace OnRamp.Controllers {
	[Authorize]
	public class SupplierController : Controller {

		private readonly IRepositorySupplierBL iRepositorySupplierBL;

		public SupplierController(IRepositorySupplierBL repositorySupplierBL) {
			iRepositorySupplierBL = repositorySupplierBL;
		}

		// GET: Supplier
		public ActionResult Index() {
			return View();
		}

		public ActionResult Add() {
			return View();
		}

		public ActionResult AddSupplier(Suppliers supplier) {
			Suppliers result = iRepositorySupplierBL.AddSupplier(supplier);
			return RedirectToAction("Index");
		}

		public JsonResult GetList() {
			List<Suppliers> suppliers = iRepositorySupplierBL.GetSupplierList();
			return Json(suppliers, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Edit(int id) {
			Suppliers supplier = iRepositorySupplierBL.GetSupplierById(id);
			return View(supplier);
		}

		public ActionResult Update(Suppliers supplier) {
			Suppliers result = iRepositorySupplierBL.UpdateSupplier(supplier);
			return RedirectToAction("Index");
		}

		public JsonResult Delete(int id) {
			bool result = iRepositorySupplierBL.RemoveSupplier(id);
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}