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
	}
}
