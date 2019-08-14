using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnRamp.Model.Models;


namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositoryCustomerBL {
		List<Customers> GetCustomerList();
	}
}
