using ExpenseManagementApp.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementApp.Admin
{
    public partial class EditCart : System.Web.UI.Page
    {
        public DataAccess dataAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess = Global.DataAccess;
            if (!IsPostBack)
            {
                int cartID = int.Parse(Request.QueryString["CartID"]);
                LoadCartItemDetails(cartID);
            }
        }

        private void LoadCartItemDetails(int cartID)
        {
            int userId = 1;
            var cartItems = dataAccess.GetCartItem(cartID,userId);

            
            ddlCategory.Items.Add(new ListItem(cartItems.CategoryName));
            ddlItems.Items.Add(new ListItem(cartItems.ItemName));
            txtPrice.Text = cartItems.Price.ToString();
            txtQuantity.Text =cartItems.Quantity.ToString();

            
            ddlCategory.Enabled = false;
            ddlItems.Enabled = false;
        }
        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            int cartID = int.Parse(Request.QueryString["CartID"]);
            int newQuantity = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);
           var update=dataAccess.UpdateCart(cartID,newQuantity,price);

            if (update)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Item updated successfully' );", true);
                Response.Redirect("Cart.aspx");
            }

            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Item updation  failed' );", true);

            }
        }



    }
}
