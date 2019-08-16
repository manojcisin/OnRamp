using OnRamp.Model.Models;
using System.Collections.Generic;

namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositoryProductBL {
		List<Products> GetProductList();
	}
}
