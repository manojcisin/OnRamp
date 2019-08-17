using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using OnRamp.Model.Models;
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
		public List<ProductDetail> GetProductListForDashBoard() {
			List<ProductDetail> productDetail = Context.Tbl_Products.AsEnumerable().OrderBy(x=>x.Product_Name)
				.Select(x => new ProductDetail {
					Product_Barcode = x.Product_Barcode,
					Product_Category = x.Tbl_Product_Category.Category_Name,
					Product_Date = x.Product_Date_Captured.ToShortDateString(),
					Product_Location = x.Product_Location,
					Product_Name = x.Product_Name,
					Product_Status = ((ProductStatus)x.Product_Status).ToString(),
					Product_Warranty = x.Product_Warranty,
					Supplier_Name  = x.Tbl_Suppliers.Supplier_Name
				}).ToList();
			return productDetail;
		}

		public ProductDetail GetProductDetailById(int id) {
			var result = Context.Tbl_Products.Where(x => x.Product_Barcode == id).FirstOrDefault();
			ProductDetail productDetail = new ProductDetail {
				Product_Barcode = result.Product_Barcode,
				Product_Category = result.Tbl_Product_Category.Category_Name,
				Product_Date = result.Product_Date_Captured.ToShortDateString(),
				Product_Location = result.Product_Location,
				Product_Name = result.Product_Name,
				Product_Status = ((ProductStatus)result.Product_Status).ToString(),
				Product_Warranty = result.Product_Warranty,
				Supplier_Name = result.Tbl_Suppliers.Supplier_Name
			};
			return productDetail;
		}
	}
}
