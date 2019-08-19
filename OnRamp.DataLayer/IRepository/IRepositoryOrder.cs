using OnRamp.DataLayer.Context;
using OnRamp.Model.Models;
using System.Collections.Generic;

namespace OnRamp.DataLayer.IRepository {
	public interface IRepositoryOrder : IRepository<Tbl_Orders> {
		List<Orders> GetOrderList();
		int GetOrderForMonth();
		int GetOutstandingPayments();
	}
}
