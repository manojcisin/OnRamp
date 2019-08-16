using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
