using OnRamp.BusinessLayer.IRepository;
using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnRamp.BusinessLayer.Repository {
	public class RepositoryCustomerBL : IRepositoryCustomerBL {

		private readonly IRepositoryCustomer iRepositoryCustomer;
		public readonly Mapper<Tbl_Customers, Customers> mapCustomers = null;

		public RepositoryCustomerBL(IRepositoryCustomer repositoryCustomer) {
			iRepositoryCustomer = repositoryCustomer;
			mapCustomers = new Mapper<Tbl_Customers, Customers>();
		}

		public List<Customers> GetCustomerList() {
			List<Customers> customerList = iRepositoryCustomer.GetCustomerList().Select(mapCustomers.MapTo).ToList();
			return customerList;
		}
	}
}
