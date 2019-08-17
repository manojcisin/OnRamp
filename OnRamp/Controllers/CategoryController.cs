using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnRamp.Controllers {
	public class CategoryController : BaseController {

		private readonly IRepositoryCategoryBL iRepositoryCategoryBL;

		public CategoryController(IRepositoryCategoryBL repositoryCategoryBL) {
			iRepositoryCategoryBL = repositoryCategoryBL;
		}

		// GET: Category
		public ActionResult Index() {
			return View();
		}

		public ActionResult Add() {
			return View();
		}

		public ActionResult AddCategory(Category categories) {
				Category result = iRepositoryCategoryBL.AddCategory(categories);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetList() {
			List<Category> categories = iRepositoryCategoryBL.GetCategoryList();
			return Json(categories, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Edit(int id)  {
			Category category = iRepositoryCategoryBL.GetCategoryById(id);
			var serializer = new JavaScriptSerializer();
			ViewBag.category = serializer.Serialize(category);
			return View(category);
		}

		public ActionResult Update(Category category) {
			Category result = iRepositoryCategoryBL.UpdateCategory(category);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Delete(int id) {
			bool result = iRepositoryCategoryBL.RemoveCategory(id);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

	}
}