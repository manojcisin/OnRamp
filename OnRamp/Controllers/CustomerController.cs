using OnRamp.BusinessLayer.IRepository;
using OnRamp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnRamp.Controllers {
	public class CustomerController : Controller {
		private readonly IRepositoryCustomerBL iRepositoryCustomerBL;

		public CustomerController(IRepositoryCustomerBL repositoryCustomerBL) {
			iRepositoryCustomerBL = repositoryCustomerBL;
		}


		// GET: Customer
		public ActionResult Index() {
			List<Customers>  customers= iRepositoryCustomerBL.GetCustomerList();
			return View();
		}
	}
}