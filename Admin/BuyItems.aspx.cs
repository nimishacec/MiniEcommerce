using ExpenseManagementApp.DataBase;
using ExpenseManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace ExpenseManagementApp.Admin
{
    public partial class BuyItems : System.Web.UI.Page
    {
        public DataAccess dataAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess = Global.DataAccess;

            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            var cat = dataAccess.GetCategories();
            ddlCategory.DataSource = cat;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }


        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "0")
            {
                LoadItemsByCategory(int.Parse(ddlCategory.SelectedValue));
            }
            else
            {
                ddlItems.Items.Clear();
                txtPrice.Text = string.Empty;
                txtQuantity.Text = string.Empty;
            }
        }
        private void LoadItemsByCategory(int categoryID)
        {
            var items = dataAccess.GetItemsbyCategory(categoryID);

            ddlItems.DataSource = items;
            ddlItems.DataTextField = "ItemName";
            ddlItems.DataValueField = "ItemID";
            ddlItems.DataBind();


            ddlItems.Items.Insert(0, new ListItem("Select Item", "0"));
        }

        protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItems.SelectedValue != "0")
            {
                LoadItemDetails(int.Parse(ddlItems.SelectedValue));
            }
            else
            {
                txtPrice.Text = string.Empty;
                txtQuantity.Text = string.Empty;
            }
        }

        private void LoadItemDetails(int itemID)
        {
            var items = dataAccess.GetItems(itemID);
            decimal price = Convert.ToDecimal(items.Price);
           int quantity = Convert.ToInt32(items.Stock);
           
            txtPrice.Text = price.ToString() ;
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            int userID = 1; 
            int categoryID = int.Parse(ddlCategory.SelectedValue);
            int itemID = int.Parse(ddlItems.SelectedValue);
            int quantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text, NumberStyles.Currency);

            var addcart = dataAccess.AddItemToCart(userID, itemID, categoryID,quantity, price);
            if(addcart)
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Item added to cart  successfully' );", true);
            else 
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Item adding to cart  failed' );", true);

        }
    }
}
      
   








