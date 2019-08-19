using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace OnRamp.DataLayer.Repository {
	public class RepositoryCategory : AbstractRepository<Tbl_Product_Category>, IRepositoryCategory {


		public Tbl_Product_Category AddCategory(Tbl_Product_Category category) {
			Context.Tbl_Product_Category.Add(category);
			Context.SaveChanges();
			category.Category_ID = category.Category_ID;
			return category;
		}

		public Tbl_Product_Category GetCategoryById(int id) {
			return Context.Tbl_Product_Category.Find(id);
		}

		public List<Tbl_Product_Category> GetCategoryList() {
			return Context.Tbl_Product_Category.ToList();
		}

		public bool RemoveCategory(int id) {
			Tbl_Product_Category category = Context.Tbl_Product_Category.Find(id);
			if (category != null) {
				var barCode = Context.Tbl_Products.Where(c => c.Product_Category_ID == id).Select(f=>f.Product_Barcode).ToList();
				Context.Tbl_Products.RemoveRange(Context.Tbl_Products.Where(x => x.Product_Category_ID == id).ToList());
				foreach (var item in barCode) {
					Context.Tbl_Orders.RemoveRange(Context.Tbl_Orders.Where(x => x.Product_Barcode == item).ToList());
				}
				
				Context.Tbl_Product_Category.Remove(category);
				Context.SaveChanges();
				return true;
			}
			else {
				return false;
			}
		}

		public Tbl_Product_Category UpdateCategory(Tbl_Product_Category tbl_Category) {
			Tbl_Product_Category category = Context.Tbl_Product_Category.Find(tbl_Category.Category_ID);
			if (category != null) {
				category.Category_Name = tbl_Category.Category_Name;
				category.Category_Description = tbl_Category.Category_Description;
				Context.SaveChanges();
				return category;
			}
			else {
				return new Tbl_Product_Category();
			}
		}
	}
}
