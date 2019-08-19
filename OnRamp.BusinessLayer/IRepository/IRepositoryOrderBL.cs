using OnRamp.Model.Models;
using System.Collections.Generic;

namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositoryOrderBL {
		List<Orders> GetOrderList();
		int GetOrderForMonth();
		int GetOutstandingPayments();
		bool UpdatePaymentStatusByOrderId(int orderId, bool paymentStatus);
	}
}
