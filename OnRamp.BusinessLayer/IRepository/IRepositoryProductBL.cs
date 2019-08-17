using OnRamp.Model.Models;
using System.Collections.Generic;

namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositoryProductBL {
		List<Products> GetProductList();
		Products Add(Products product);
		object GetProductInStocks();
		List<ProductDetail> GetProductListForDashBoard();
	}
}
