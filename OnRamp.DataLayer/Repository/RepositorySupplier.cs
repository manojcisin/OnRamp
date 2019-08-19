using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer.Repository {
	public class RepositorySupplier : AbstractRepository<Tbl_Suppliers>, IRepositorySupplier {
		public Tbl_Suppliers AddSupplier(Tbl_Suppliers supplier) {
			Context.Tbl_Suppliers.Add(supplier);
			Context.SaveChanges();
			supplier.Supplier_ID = supplier.Supplier_ID;
			return supplier;
		}

		public Tbl_Suppliers GetSupplierById(int id) {
			return Context.Tbl_Suppliers.Find(id);
		}

		public List<Tbl_Suppliers> GetSupplierList() {
			return Context.Tbl_Suppliers.ToList();
		}

		public Tbl_Suppliers UpdateSupplier(Tbl_Suppliers tbl_Suppliers) {
			Tbl_Suppliers supplier = Context.Tbl_Suppliers.Find(tbl_Suppliers.Supplier_ID);
			if (supplier != null) {
				supplier.Supplier_Name = tbl_Suppliers.Supplier_Name;
				supplier.Supplier_Telephone_Number = tbl_Suppliers.Supplier_Telephone_Number;
				supplier.Supplier_Email = tbl_Suppliers.Supplier_Email;
				Context.SaveChanges();
				return supplier;
			}
			else {
				return new Tbl_Suppliers();
			}
		}

		public bool RemoveSupplier(int id) {
			Tbl_Suppliers supplier = Context.Tbl_Suppliers.Find(id);
			if (supplier != null) {
				Context.Tbl_Products.RemoveRange(Context.Tbl_Products.Where(x => x.Supplier_ID == id).ToList());
				Context.Tbl_Suppliers.Remove(supplier);
				Context.SaveChanges();
				return true;
			}
			else {
				return false;
			}
		}

	}
}
