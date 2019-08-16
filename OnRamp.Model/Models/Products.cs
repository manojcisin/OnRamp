using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.Model.Models {
	public class Products {

		public int Product_Barcode { get; set; }
		public int Product_Category_ID { get; set; }
		public string Product_Name { get; set; }
		public DateTime Product_Date_Captured { get; set; }
		public int Supplier_ID { get; set; }
		public string Product_Location { get; set; }
		public int Product_Warranty { get; set; }
		public int Product_Status { get; set; }
	}
}
