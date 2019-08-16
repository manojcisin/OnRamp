using OnRamp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositoryCategoryBL {
		List<Category> GetCategoryList();
		Category AddCategory(Category categories);
		Category UpdateCategory(Category categories);
		Category GetCategoryById(int id);
		bool RemoveCategory(int id);
	}
}
