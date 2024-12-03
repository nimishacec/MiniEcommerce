using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseManagementApp.Models
{
    public class Items
    {
        public int CartID {  get; set; }
        public int CategoryID { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
    }
}