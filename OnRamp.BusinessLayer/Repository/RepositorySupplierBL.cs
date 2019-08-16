using OnRamp.BusinessLayer.IRepository;
using System.Collections.Generic;
using System.Linq;
using OnRamp.Model.Models;
using OnRamp.DataLayer.IRepository;
using OnRamp.DataLayer.Context;

namespace OnRamp.BusinessLayer.Repository {
	public class RepositorySupplierBL : IRepositorySupplierBL {
		private readonly IRepositorySupplier iRepositorySupplier;
		public readonly Mapper<Tbl_Suppliers, Suppliers> mapSupplier = null;

		public RepositorySupplierBL(IRepositorySupplier repositorySupplier) {
			iRepositorySupplier = repositorySupplier;
			mapSupplier = new Mapper<Tbl_Suppliers, Suppliers>();
		}

		public Suppliers AddSupplier(Suppliers supplier) {
			var result = iRepositorySupplier.AddSupplier(mapSupplier.MapFrom(supplier));
			return mapSupplier.MapTo(result);
		}

		public Suppliers GetSupplierById(int id) {
			var result = iRepositorySupplier.GetSupplierById(id);
			return mapSupplier.MapTo(result);
		}

		public List<Suppliers> GetSupplierList() {
			return iRepositorySupplier.GetSupplierList().Select(mapSupplier.MapTo).ToList();
		}

		public bool RemoveSupplier(int id) {
			return iRepositorySupplier.RemoveSupplier(id);
		}

		public Suppliers UpdateSupplier(Suppliers Suppliers) {
			var result = iRepositorySupplier.UpdateSupplier(mapSupplier.MapFrom(Suppliers));
			return mapSupplier.MapTo(result);
		}
	}
}
