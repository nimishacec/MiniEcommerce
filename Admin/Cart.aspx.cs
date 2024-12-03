using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpenseManagementApp.DataBase;
using System.Drawing.Printing;

namespace ExpenseManagementApp.Admin
{
    public partial class Cart : System.Web.UI.Page
    {
        public DataAccess dataAccess; 
        PagedDataSource pds = new PagedDataSource();
        
        protected int pageSize = 5;
        public int currentPage
        {
            get
            {
                return ViewState["currentPage"] != null ? (int)ViewState["currentPage"] : 1;
            }
            set
            {
                ViewState["currentPage"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess=Global.DataAccess;
            if (!IsPostBack)
            {
                if (Request.QueryString["page"] != null)
                {
                    currentPage = int.Parse(Request.QueryString["page"]);
                }
                else
                {
                    currentPage = 1;
                }
                int userID = 1;
                LoadCartItems(userID);
                lblSubtotal.Text = CalculateSubtotal(userID).ToString("C");
            }

        }
        private void LoadCartItems(int userID)
        {
           
            var cart=dataAccess.GetCartItems(userID);
            pds.DataSource = cart;
            pds.AllowPaging = true;
            pds.PageSize = pageSize;
            pds.CurrentPageIndex = currentPage - 1; // Pages are zero-based


            gvCartItems.DataSource = pds;
            gvCartItems.DataBind();

            lnkPrevious.Enabled = !pds.IsFirstPage;
            lnkNext.Enabled = !pds.IsLastPage;

            lblPageInfo.Text = $"Page {currentPage} of {pds.PageCount}";
           

           
        }
        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            currentPage = Request.QueryString["page"] != null ? int.Parse(Request.QueryString["page"]) : 1;
            currentPage -= 1;
            Response.Redirect("Cart.aspx?page=" + currentPage);
        }

        // Event handler for the "Next" button click
        protected void lnkNext_Click(object sender, EventArgs e)
        {
            currentPage = Request.QueryString["page"] != null ? int.Parse(Request.QueryString["page"]) : 1;
            currentPage += 1;
            Response.Redirect("Cart.aspx?page=" + currentPage);
        }
        protected void gvCartItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                
                int cartID = Convert.ToInt32(e.CommandArgument);               
                var remove=dataAccess.RemoveCartItem(cartID);

                if(remove)
                    ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Item removed from cart  successfully' );", true);
               else 
                    ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Item removing from cart  failed' );", true);

                LoadCartItems(1);
            }
            else if (e.CommandName == "EditQuantity")
            {
                int cartID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditCart.aspx?CartID={cartID}");
            }
        }

        public decimal CalculateSubtotal(int userID)
        {
            decimal subtotal = 0;
            subtotal = dataAccess.CalculateSubtotal(userID);
            return subtotal;
        }
        protected void gvCartItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCartItems.PageIndex = e.NewPageIndex;
            int userID = 1; // Replace with actual user retrieval logic
            LoadCartItems(userID); // Rebind data
        }
        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
           
            int userId = 1;
          
             var order=  dataAccess.OrderItems(userId);

            if (order)
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Ordered successfully' );", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Order  failed' );", true);

           
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int userID = 1;
            var order=dataAccess.OrderItems(userID);
            if(order)
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Ordered successfully' );", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Order  failed' );", true);

           Response.Redirect("OrdersPage.aspx");
        }


    }
}