using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace OnRamp.DataLayer.Repository {
	public class RepositoryCustomer : AbstractRepository<Tbl_Customers>, IRepositoryCustomer {


		public Tbl_Customers AddCustomer(Tbl_Customers customer) {
			Context.Tbl_Customers.Add(customer);
			Context.SaveChanges();
			customer.Customer_ID = customer.Customer_ID;
			return customer;
		}

		public Tbl_Customers GetCustomerById(int id) {
			return Context.Tbl_Customers.Find(id);
		}

		public List<Tbl_Customers> GetCustomerList() {
			return Context.Tbl_Customers.ToList();
		}

		public Tbl_Customers UpdateCustomer(Tbl_Customers tbl_Customers) {
			Tbl_Customers customer = Context.Tbl_Customers.Find(tbl_Customers.Customer_ID);
			if (customer != null) {
				customer.Customer_Name = tbl_Customers.Customer_Name;
				customer.Customer_Telephone_Number = tbl_Customers.Customer_Telephone_Number;
				customer.Customer_Email = tbl_Customers.Customer_Email;
				Context.SaveChanges();
				return customer;
			}
			else {
				return new Tbl_Customers();
			}
		}

		public bool RemoveCustomer(int id) {
			Tbl_Customers customer = Context.Tbl_Customers.Find(id);
			if (customer != null) {
				Context.Tbl_Orders.RemoveRange(Context.Tbl_Orders.Where(x => x.Customer_ID == id).ToList());
				Context.Tbl_Customers.Remove(customer);
				Context.SaveChanges();
				return true;
			}
			else {
				return false;
			}
		}

		
	}

}
