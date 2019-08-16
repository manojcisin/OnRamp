using OnRamp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.BusinessLayer.IRepository {
	public interface IRepositorySupplierBL {
		List<Suppliers> GetSupplierList();
		Suppliers AddSupplier(Suppliers supplier);
		Suppliers UpdateSupplier(Suppliers Suppliers);
		Suppliers GetSupplierById(int id);
		bool RemoveSupplier(int id);
	}
}
