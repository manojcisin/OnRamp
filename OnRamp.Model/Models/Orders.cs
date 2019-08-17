using System;

namespace OnRamp.Model.Models {
	public class Orders {
		public int Order_ID { get; set; }
		public string Order_Number { get; set; }
		public int Customer_ID { get; set; }
		public string Customer_Name { get; set; }
		public DateTime Date_Sold { get; set; }
		public bool Payment_Received { get; set; }

		public string Payment_Status
		{
			get { return Payment_Received ? "Received" : "Not Received"; }
		}

	}
}
