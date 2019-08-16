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
		public readonly Mapper<Tbl_Products, Products> mapCustomers = null;

		public RepositoryProductBL(IRepositoryProduct repositoryProduct) {
			iRepositoryProduct = repositoryProduct;
			mapCustomers = new Mapper<Tbl_Products, Products>();
		}

		public List<Products> GetProductList() {
			try {
				List<Products> customerList = iRepositoryProduct.GetProductList().Select(mapCustomers.MapTo).ToList();
				return customerList;
			}
			catch (Exception ex) {
				throw ex;

			}
		}



	}
}
