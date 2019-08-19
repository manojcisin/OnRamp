using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OnRamp.DataLayer.Context;
using OnRamp.DataLayer.IRepository;
using System;
using OnRamp.Model.Models;

namespace OnRamp.DataLayer.Repository {
	public class RepositoryOrder : AbstractRepository<Tbl_Orders>, IRepositoryOrder {		
		/// <summary>
		/// This is used to get Order list
		/// </summary>
		/// <returns></returns>

		public List<Orders> GetOrderList() {
			List<Orders> orderList = Context.Tbl_Orders.ToList().Select(x => new Orders {
				Order_ID = x.Order_ID,
				Customer_ID = x.Customer_ID,
				Customer_Name = x.Tbl_Customers.Customer_Name,
				Date_Sold = x.Date_Sold.ToShortDateString(),
				Payment_Received = x.Payment_Received,
				Product_Barcode = x.Tbl_Products.Product_Barcode,
				Product_Name = x.Tbl_Products.Product_Name,
				Supplier_ID = x.Supplier_ID,
				Supplier_Name = x.Tbl_Suppliers.Supplier_Name,
				Product_Status = (int) x.Tbl_Products.Product_Status
			}).OrderByDescending(x => x.Order_ID).ToList();
			return orderList;
		}

		public int GetOrderForMonth() {
			return Context.Tbl_Orders.Where(x => x.Date_Sold.Month == DateTime.Now.Month && x.Date_Sold.Year == DateTime.Now.Year).ToList().Count();			
		}
		public int GetOutstandingPayments() {
			return Context.Tbl_Orders.Where(x => !x.Payment_Received).Count();
		}
	}
}
