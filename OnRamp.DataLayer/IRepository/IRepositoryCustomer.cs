using OnRamp.DataLayer.Context;
using System.Collections.Generic;

namespace OnRamp.DataLayer.IRepository {
	public interface IRepositoryCustomer : IRepository<Tbl_Customers> {

		//List<Tbl_Customers> GetCustomerList();
		List<Tbl_Customers> GetCustomerList();
		Tbl_Customers AddCustomer(Tbl_Customers customer);
		Tbl_Customers UpdateCustomer(Tbl_Customers tbl_Customers);
		Tbl_Customers GetCustomerById(int id);
		bool RemoveCustomer(int id);
	}
}
