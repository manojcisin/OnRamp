using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using System;

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

		public int GetOrderForMonth() {
			return Context.Tbl_Orders.Where(x => x.Date_Sold.Month == DateTime.Now.Month && x.Date_Sold.Year == DateTime.Now.Year).ToList().Count();			
		}
		public int GetOutstandingPayments() {
			return Context.Tbl_Orders.Where(x => !x.Payment_Received).Count();
		}
	}
}
