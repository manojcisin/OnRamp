

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OnRamp.Helpers.Enums {
	/// <summary>
	/// this enum for EPaymentStatus
	/// </summary>
	public enum EPaymentStatus {

		[Description("Recieved")]
		Received = 1,
		[Description("Not Recieved")]
		NotReceived = 0,
		
	}

	public static class EPaymentStatusHelper {
		#region Class Methods



		public static IEnumerable<string> List() {
			return new List<string> {
				EPaymentStatus.Received.ToString(),
				EPaymentStatus.NotReceived.ToString(),
				
	};
		}


		public static string GetEnumDescription(EPaymentStatus value) {
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

		public static EPaymentStatus Parse(string sEnum) {
			return (EPaymentStatus)Enum.Parse(typeof(EPaymentStatusHelper), sEnum, true);
		}

		public static EPaymentStatus Parse(int sEnum) {
			return (EPaymentStatus)Enum.ToObject(typeof(EPaymentStatus), sEnum);
		}
		public static EPaymentStatus Parse(double sEnum) {
			return (EPaymentStatus)Enum.ToObject(typeof(EPaymentStatus), sEnum);
		}

		public static string ToString(EPaymentStatus eEnum) {
			return Enum.GetName(typeof(EPaymentStatus), eEnum);
		}

		public static string ToString(int eEnum) {
			return Enum.GetName(typeof(EPaymentStatus), eEnum);
		}

		#endregion
	}
}