using OnRamp.BusinessLayer;
using OnRamp.DataLayer.Context;
using OnRamp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnRamp.App_Start {
	public class AutoMapperConfig {
		public static void CreateMappings() {
			AutoMapperHelper.CreateMapping<Tbl_Customers, Customers>();
			AutoMapperHelper.CreateMapping<Tbl_Product_Category, Category>();
			AutoMapperHelper.CreateMapping<Tbl_Suppliers, Suppliers>();
			AutoMapperHelper.CreateMapping<Tbl_Products, Products>();
		}
	}
}