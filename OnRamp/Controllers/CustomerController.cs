using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnRamp.Controllers {
	public class CustomerController : Controller {
		private readonly IRepositoryCustomerBL iRepositoryCustomerBL;

		public CustomerController(IRepositoryCustomerBL repositoryCustomerBL) {
			iRepositoryCustomerBL = repositoryCustomerBL;
		}

		// GET: Customer
		public ActionResult Index() {
			return View();
		}


		/// <summary>
		/// this is used to get supplier list
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		
		[HttpGet]
		public ActionResult GetCusotmerList() 
	    {
			List<Customers>  customers= iRepositoryCustomerBL.GetCusotmerList();
			return View();
		}


		/// <summary>
		/// This is used to add the Customer
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>

		[HttpPost]
		public ActionResult AddCustomer(Customers model) {

			var customers = iRepositoryCustomerBL.AddCustomer(model);

			return View();

		}

		/// <summary>
		/// This is used to update the Customer
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>

		[HttpPost]
		public ActionResult UpdateCustomer(Customers model) {

			var customers = iRepositoryCustomerBL.UpdateCustomer(model);

			return View();

		}

		/// <summary>
		/// This is used to get Customer by Id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>

		[HttpGet]
		public ActionResult GetCustomerById(int Id) {

			var customers = iRepositoryCustomerBL.GetCustomerById(Id);

			return View();

		}
		/// <summary>
		/// This is used to Delete Customer By Id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet]
		public ActionResult RemoveCustomer(int Id) {

			var result = iRepositoryCustomerBL.RemoveCustomer(Id);

			return View();

		}

	}
}