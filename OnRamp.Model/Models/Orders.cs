using System;

namespace OnRamp.Model.Models {
	public class Orders {
		public int Order_ID { get; set; }		
		public int Customer_ID { get; set; }
		public string Customer_Name { get; set; }
		public string Date_Sold { get; set; }
		public bool Payment_Received { get; set; }
		public int Product_Barcode { get; set; }
		public string Product_Name { get; set; }
		public int Supplier_ID { get; set; }
		public string Supplier_Name { get; set; }		
		public int Product_Status { get; set;}
		public string Payment_Status
		{
			get { return Payment_Received ? "Received" : "Not Received"; }
		}
	}
}
