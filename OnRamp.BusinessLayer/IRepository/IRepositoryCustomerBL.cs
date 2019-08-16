using System.Collections.Generic;
using OnRamp.Model.Models;


namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositoryCustomerBL {
		List<Customers> GetCusotmerList();
		Customers AddCustomer(Customers customers);
		Customers UpdateCustomer(Customers customers);
		Customers GetCustomerById(int id);
		bool RemoveCustomer(int id);
	}
}
