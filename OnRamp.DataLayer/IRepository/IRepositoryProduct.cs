using OnRamp.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer.IRepository {
	public interface IRepositoryProduct : IRepository<Tbl_Products> {
		
		List<Tbl_Products> GetProductList();
		Tbl_Products Add(Tbl_Products products);
		object GetProductInStocks();
	}
}
