using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseManagementApp.Models
{
    public class Orders
    {
        public int OrderID { get; set; }      
        public int UserID { get; set; }       
        public int ItemID { get; set; }       
        public int Quantity { get; set; }     
        public decimal UnitPrice { get; set; } 
        public decimal TotalPrice { get; set; } 
        public decimal TotalAmount { get; set; } 
        public DateTime OrderDate { get; set; } 
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }
}