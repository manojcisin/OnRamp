using System;
using System.ComponentModel.DataAnnotations;

namespace OnRamp.Model.Models {
	public class Products {
		public int Product_Barcode { get; set; }
		[Required(ErrorMessage = "Please select the category")]
		public int Product_Category_ID { get; set; }
		[Required(ErrorMessage ="Please enter the product name")]
		public string Product_Name { get; set; }
		[Required(ErrorMessage = "Please select the product date")]
		public DateTime Product_Date_Captured { get; set; }
		[Required(ErrorMessage = "Please select the supplier")]
		public int Supplier_ID { get; set; }
		public string Product_Location { get; set; }
		public int? Product_Warranty { get; set; }
		[Required(ErrorMessage = "Please select the status")]
		public int? Product_Status { get; set; }
	}

	public class ProductDetail {
		public int Product_Barcode { get; set; }
		public string Product_Category { get; set; }
		public string Product_Name { get; set; }
		public string Product_Date { get; set; }
		public string Supplier_Name { get; set; }
		public string Product_Location { get; set; }
		public int? Product_Warranty { get; set; }
		public string Product_Status { get; set; }
	}

	public enum ProductStatus {
		Sold = 1,
		Returned = 2,
		Defective = 3
	}
		
}
