using OnRamp.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer.IRepository {
	public interface IRepositorySupplier : IRepository<Tbl_Suppliers> {
		List<Tbl_Suppliers> GetSupplierList();
		Tbl_Suppliers AddSupplier(Tbl_Suppliers supplier);
		Tbl_Suppliers UpdateSupplier(Tbl_Suppliers tbl_Suppliers);
		Tbl_Suppliers GetSupplierById(int id);
		bool RemoveSupplier(int id);
	}
}
