using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer.Repository {
	public class RepositoryProduct : AbstractRepository<Tbl_Products>, IRepositoryProduct {

		public List<Tbl_Products> GetProductList() {
			return Context.Tbl_Products.ToList();
		}

		public Tbl_Products Add(Tbl_Products products) {
			Context.Tbl_Products.Add(products);
			Context.SaveChanges();
			products.Product_Barcode = products.Product_Barcode;
			return products;
		}

		public object GetProductInStocks() {
			var result = Context.Tbl_Product_Category.ToList()
				.Select(x => new {
					CategoryName = x.Category_Name,
					ProductCount = x.Tbl_Products.ToList().Count()
				}).ToList();			
			return result;
		}
	}
}
