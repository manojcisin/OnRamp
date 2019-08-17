using OnRamp.BusinessLayer.IRepository;
using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using OnRamp.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnRamp.BusinessLayer.Repository {
	public class RepositoryOrderBL : IRepositoryOrderBL {

		private readonly IRepositoryOrder iRepositoryOrder;
		public readonly Mapper<Tbl_Orders, Orders> mapOrders = null;



		public RepositoryOrderBL(IRepositoryOrder repositoryOrder) {
			iRepositoryOrder = repositoryOrder;
			mapOrders = new Mapper<Tbl_Orders, Orders>();
		}


		public List<Orders> GetOrderList() {
			var result = iRepositoryOrder.GetOrderList();

			var orders = new List<Orders>();
			orders = (from p in result
					  select new Orders {
						  Order_Number = p.Order_Number,
						  Customer_Name = p.Tbl_Customers.Customer_Name,
						  Date_Sold = p.Date_Sold,
						  Payment_Received = p.Payment_Received

					  }).ToList();


			return orders.ToList();

		}

		public int GetOrderForMonth() {
			return iRepositoryOrder.GetOrderForMonth();
		}

		public int GetOutstandingPayments() {
			return iRepositoryOrder.GetOutstandingPayments();
		}
	}
}
