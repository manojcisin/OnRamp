using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnRamp.Controllers {
	public class ProductController : Controller
    {
		private readonly IRepositoryProductBL iRepositoryProductBL;

		public ProductController(IRepositoryProductBL repositoryProdcutBL) {
			iRepositoryProductBL = repositoryProdcutBL;
		}

		// GET: Product
		public ActionResult Index()
        {
			List<Products>  products= iRepositoryProductBL.GetProductList();
			return View();
		}
    }
}