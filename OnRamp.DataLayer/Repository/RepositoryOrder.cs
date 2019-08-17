using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;

namespace OnRamp.DataLayer.Repository {
	public class RepositoryOrder : AbstractRepository<Tbl_Orders>, IRepositoryOrder {


		

		/// <summary>
		/// This is used to get Order list
		/// </summary>
		/// <returns></returns>

		public List<Tbl_Orders> GetOrderList() {
		var orderList = Context.Tbl_Orders.Include(i => i.Tbl_Customers).ToList();
			return orderList;
		}

		
	}
}
