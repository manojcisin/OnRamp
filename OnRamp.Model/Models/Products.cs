using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.Model.Models {
	public class Products {
		public int Product_Barcode { get; set; }
		[Required]
		public int Product_Category_ID { get; set; }
		[Required]
		public string Product_Name { get; set; }		
		public System.DateTime Product_Date_Captured { get; set; }
		[Required]
		public int Supplier_ID { get; set; }
		public string Product_Location { get; set; }
		public Nullable<int> Product_Warranty { get; set; }
		[Required]
		public Nullable<int> Product_Status { get; set; }
	}

	public class ProductDetail {
		public int Product_Barcode { get; set; }
		public string Product_Category { get; set; }
		public string Product_Name { get; set; }
		public string Product_Date { get; set; }
		public string Supplier_Name { get; set; }
		public string Product_Location { get; set; }
		public Nullable<int> Product_Warranty { get; set; }
		public string Product_Status { get; set; }
	}

	public enum ProductStatus {
		Sold = 1,
		Returned = 2,
		Defective = 3
	}

	public enum PaymentStatus {
		Received = 0,
		NotReceived = 1
	}
		
}
