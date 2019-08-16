using System.Collections.Generic;
using System.Linq;
using OnRamp.BusinessLayer.IRepository;
using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using OnRamp.Model.Models;

namespace OnRamp.BusinessLayer.Repository {

	public class RepositoryCategoryBL : IRepositoryCategoryBL {

		private readonly IRepositoryCategory iRepositoryCategory;
		public readonly Mapper<Tbl_Product_Category, Category> mapCategories = null;



		public RepositoryCategoryBL(IRepositoryCategory repositoryCategory) {
			iRepositoryCategory = repositoryCategory;
			mapCategories = new Mapper<Tbl_Product_Category, Category>();
		}


		public Category AddCategory(Category categories) {
			var result = iRepositoryCategory.AddCategory(mapCategories.MapFrom(categories));
			return mapCategories.MapTo(result);
		}

		public Category GetCategoryById(int id) {

			var result = iRepositoryCategory.GetCategoryById(id);
			return mapCategories.MapTo(result);
		}

		public List<Category> GetCategoryList() {
			return iRepositoryCategory.GetCategoryList().Select(mapCategories.MapTo).ToList();
		}

		public bool RemoveCategory(int id) {
			return iRepositoryCategory.RemoveCategory(id);
		}

		public Category UpdateCategory(Category categories) {
			var result = iRepositoryCategory.UpdateCategory(mapCategories.MapFrom(categories));
			return mapCategories.MapTo(result);
		}
	}
}
