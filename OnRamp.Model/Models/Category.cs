using System.ComponentModel.DataAnnotations;

namespace OnRamp.Model.Models {

	public class Category {
		public int Category_ID { get; set; }
		[Required]
		public string Category_Name { get; set; }
		[Required]
		public string Category_Description { get; set; }
	}
}
