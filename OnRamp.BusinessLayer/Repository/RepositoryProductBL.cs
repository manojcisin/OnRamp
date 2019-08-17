using OnRamp.BusinessLayer.IRepository;
using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using OnRamp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.BusinessLayer.Repository {
	public class RepositoryProductBL : IRepositoryProductBL {

		private readonly IRepositoryProduct iRepositoryProduct;
		public readonly Mapper<Tbl_Products, Products> mapProducts = null;

		public RepositoryProductBL(IRepositoryProduct repositoryProduct) {
			iRepositoryProduct = repositoryProduct;
			mapProducts = new Mapper<Tbl_Products, Products>();
		}

		public List<Products> GetProductList() {
			List<Products> customerList = iRepositoryProduct.GetProductList().Select(mapProducts.MapTo).ToList();
			return customerList;
		}

		public Products Add(Products product) {
			var result = iRepositoryProduct.Add(mapProducts.MapFrom(product));
			return mapProducts.MapTo(result) ;
		}

		public object GetProductInStocks() {
			return iRepositoryProduct.GetProductInStocks();
		}

		public List<ProductDetail> GetProductListForDashBoard() {
			return iRepositoryProduct.GetProductListForDashBoard();
		}

		public ProductDetail GetProductDetailById(int id) {
			return iRepositoryProduct.GetProductDetailById(id);
		}
	}
}
