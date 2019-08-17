using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnRamp.Controllers {
	public class ProductController : Controller {
		private readonly IRepositoryProductBL iRepositoryProductBL;
		private readonly IRepositoryCategoryBL iRepositoryCategoryBL;
		private readonly IRepositorySupplierBL iRepositorySupplierBL;

		public ProductController(IRepositoryProductBL repositoryProdcutBL,
			IRepositoryCategoryBL repositoryCategoryBL,
			IRepositorySupplierBL repositorySupplierBL) {
			iRepositoryProductBL = repositoryProdcutBL;
			iRepositoryCategoryBL = repositoryCategoryBL;
			iRepositorySupplierBL = repositorySupplierBL;
		}
				
		public ActionResult Index() {			
			return View();
		}

		public ActionResult AddProductView() {
			ViewBag.CategoryList = iRepositoryCategoryBL.GetCategoryList()
				.Select(x => new SelectListItem { Text = x.Category_Name, Value = x.Category_ID.ToString() }).ToList();
			ViewBag.SupplierList = iRepositorySupplierBL.GetSupplierList()
				.Select(x => new SelectListItem { Text = x.Supplier_Name, Value = x.Supplier_ID.ToString() }).ToList();
			ViewBag.ProductStatus = Enum.GetValues(typeof(ProductStatus)).OfType<ProductStatus>().ToList()
				.Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
			return PartialView();
		}

		public ActionResult Add(Products product) {
			var result = iRepositoryProductBL.Add(product);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetProductInStocks() {
			var result = iRepositoryProductBL.GetProductInStocks();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetProductListForDashBoard() {
			var result = iRepositoryProductBL.GetProductListForDashBoard();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

	}
}