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
			return result;
		}

		public int GetOrderForMonth() {
			return iRepositoryOrder.GetOrderForMonth();
		}

		public int GetOutstandingPayments() {
			return iRepositoryOrder.GetOutstandingPayments();
		}
	}
}
