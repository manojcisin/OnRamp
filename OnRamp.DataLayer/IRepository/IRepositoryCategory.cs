using OnRamp.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer.IRepository {
	public interface IRepositoryCategory : IRepository<Tbl_Product_Category> {

		List<Tbl_Product_Category> GetCategoryList();
		Tbl_Product_Category AddCategory(Tbl_Product_Category category);
		Tbl_Product_Category UpdateCategory(Tbl_Product_Category tbl_Category);
		Tbl_Product_Category GetCategoryById(int id);
		bool RemoveCategory(int id);
	}
}
