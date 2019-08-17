using OnRamp.BusinessLayer.IRepository;
using System.Collections.Generic;
using System.Web.Mvc;
using OnRamp.Model.Models;
using System.Web.Script.Serialization;

namespace OnRamp.Controllers {

	public class SupplierController : BaseController {

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

		/// <summary>
		/// This is used to Add Supplier 
		/// </summary>
		/// <param name="supplier"></param>
		/// <returns></returns>
		public ActionResult AddSupplier(Suppliers supplier) {
			Suppliers result = iRepositorySupplierBL.AddSupplier(supplier);
			return Json(result, JsonRequestBehavior.AllowGet);
		}
		/// <summary>
		/// This is used to get Supplier data
		/// </summary>
		/// <returns></returns>
		public JsonResult GetList() {
			List<Suppliers> suppliers = iRepositorySupplierBL.GetSupplierList();
			return Json(suppliers, JsonRequestBehavior.AllowGet);
		}
		/// <summary>
		/// This is used to get Supplier by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Edit(int id) {
			Suppliers supplier = iRepositorySupplierBL.GetSupplierById(id);
			var serializer = new JavaScriptSerializer();
			ViewBag.supplier = serializer.Serialize(supplier);
			return View();
		}

		/// <summary>
		/// This is used to Update the Supplier
		/// </summary>
		/// <param name="supplier"></param>
		/// <returns></returns>
		public ActionResult Update(Suppliers supplier) {
			Suppliers result = iRepositorySupplierBL.UpdateSupplier(supplier);
			return Json(result, JsonRequestBehavior.AllowGet);

		}

		/// <summary>
		/// This is used to Delete Supplier By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public JsonResult Delete(int id) {
			bool result = iRepositorySupplierBL.RemoveSupplier(id);
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}