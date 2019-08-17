using OnRamp.DataLayer.Context;
using System.Collections.Generic;

namespace OnRamp.DataLayer.IRepository {
	public interface IRepositoryOrder : IRepository<Tbl_Orders> {

		List<Tbl_Orders> GetOrderList();

	}
}
