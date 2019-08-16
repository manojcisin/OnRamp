using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnRamp.Controllers {
	public class CategoryController : Controller {

		private readonly IRepositoryCategoryBL iRepositoryCategoryBL;

		public CategoryController(IRepositoryCategoryBL repositoryCategoryBL) {
			iRepositoryCategoryBL = repositoryCategoryBL;
		}

		// GET: Category
		public ActionResult Index() {
			return View();
		}

		/// <summary>
		/// this is used to get category list
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>

		[HttpGet]
		public ActionResult GetCategoryList() {
			List<Category> customers = iRepositoryCategoryBL.GetCategoryList();
			return View();
		}


		/// <summary>
		/// This is used to add the Category
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>

		[HttpPost]
		public ActionResult AddCategory(Category model) {

			var category = iRepositoryCategoryBL.AddCategory(model);

			return View();

		}

		/// <summary>
		/// This is used to update the Category
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>

		[HttpPost]
		public ActionResult UpdateCategory(Category model) {

			var category = iRepositoryCategoryBL.UpdateCategory(model);

			return View();

		}

		/// <summary>
		/// This is used to get Category by Id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>

		[HttpGet]
		public ActionResult GetCategoryById(int Id) {

			var category = iRepositoryCategoryBL.GetCategoryById(Id);

			return View();

		}
		/// <summary>
		/// This is used to Delete Category By Id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet]
		public ActionResult RemoveCategory(int Id) {

			var result = iRepositoryCategoryBL.RemoveCategory(Id);

			return View();

		}


	}
}