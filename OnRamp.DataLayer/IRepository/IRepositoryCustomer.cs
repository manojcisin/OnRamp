using OnRamp.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer.IRepository {	
	public interface IRepositoryCustomer : IRepository<Tbl_Customers> {
		//Tbl_Customers GetCustomerById(int lifeId);		
		List<Tbl_Customers> GetCustomerList();
		//Tbl_Customers GetLifeByNameAndCompanyId(string name, int companyId);
		//int GetMaxOrderNoByCompanyId(int companyId);
	}
}
