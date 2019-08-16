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

		public List<Customers> GetCusotmerList() {
		return iRepositoryCustomer.GetCustomerList().Select(mapCustomers.MapTo).ToList();
		}

		public Customers AddCustomer(Customers customers) {
			var result = iRepositoryCustomer.AddCustomer(mapCustomers.MapFrom(customers));
			return mapCustomers.MapTo(result);
		}

		public Customers UpdateCustomer(Customers customers) {
			var result = iRepositoryCustomer.UpdateCustomer(mapCustomers.MapFrom(customers));
			return mapCustomers.MapTo(result);
		}

		public Customers GetCustomerById(int id) {
			var result = iRepositoryCustomer.GetCustomerById(id);
			return mapCustomers.MapTo(result);
		}

		public bool RemoveCustomer(int id) {
			return iRepositoryCustomer.RemoveCustomer(id);
		}
	}
}
