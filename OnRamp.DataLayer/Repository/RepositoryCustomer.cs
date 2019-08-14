using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer.Repository {
	public class RepositoryCustomer : AbstractRepository<Tbl_Customers>, IRepositoryCustomer {
		public List<Tbl_Customers> GetCustomerList() {
			return Context.Tbl_Customers.ToList();
		}
	}

}
