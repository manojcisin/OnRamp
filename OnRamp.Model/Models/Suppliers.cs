using System.ComponentModel.DataAnnotations;

namespace OnRamp.Model.Models {
	public class Suppliers {
		public int Supplier_ID { get; set; }
		[Required]
		public string Supplier_Name { get; set; }
		[Required]
		public string Supplier_Email { get; set; }
		[Required,MaxLength(10)]
		public string Supplier_Telephone_Number { get; set; }
	}
}
