using OnRamp.Model.Models;
using System.Collections.Generic;

namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositoryProductBL {
		List<Products> GetProductList();
		Products Add(Products product);
		object GetProductInStocks();
		List<ProductDetail> GetProductListForDashBoard();
		ProductDetail GetProductDetailById(int id);
		bool UpdateProductStatusByProductBarcode(int productBarcode, int productStatus);
	}
}
