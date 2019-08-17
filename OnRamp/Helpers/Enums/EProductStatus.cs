using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OnRamp.Helpers.Enums {
	/// <summary>
	/// this enum for EProductStatus
	/// </summary>
	public enum EProductStatus {

		[Description("Sold")]
		Sold = 1,
		[Description("Returned")]
		Returned = 2,
		[Description("Defective")]
		Defective = 3,

	}

	public static class EProductStatusHelper {
		#region Class Methods



		public static IEnumerable<string> List() {
			return new List<string> {

				EProductStatus.Sold.ToString(),
				EProductStatus.Returned.ToString(),
				EProductStatus.Defective.ToString(),
	};
		}


		public static string GetEnumDescription(EProductStatus value) {
			var fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute),
				false);

			if (attributes != null &&
				attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}

		public static EProductStatus Parse(string sEnum) {
			return (EProductStatus)Enum.Parse(typeof(EProductStatusHelper), sEnum, true);
		}

		public static EProductStatus Parse(int sEnum) {
			return (EProductStatus)Enum.ToObject(typeof(EProductStatus), sEnum);
		}
		public static EProductStatus Parse(double sEnum) {
			return (EProductStatus)Enum.ToObject(typeof(EProductStatus), sEnum);
		}

		public static string ToString(EProductStatus eEnum) {
			return Enum.GetName(typeof(EProductStatus), eEnum);
		}

		public static string ToString(int eEnum) {
			return Enum.GetName(typeof(EProductStatus), eEnum);
		}

		#endregion
	}
}