using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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
			return RedirectToAction("Index");
		}

		public JsonResult GetList() {
			List<Category> categories = iRepositoryCategoryBL.GetCategoryList();
			return Json(categories, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Edit(int id) {
			Category category = iRepositoryCategoryBL.GetCategoryById(id);
			return View(category);
		}

		public ActionResult Update(Category category) {
			Category result = iRepositoryCategoryBL.UpdateCategory(category);
			return RedirectToAction("Index");
		}

		public JsonResult Delete(int id) {
			bool result = iRepositoryCategoryBL.RemoveCategory(id);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

	}
}