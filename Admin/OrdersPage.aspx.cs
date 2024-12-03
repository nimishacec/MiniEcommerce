using ExpenseManagementApp.DataBase;
using ExpenseManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementApp.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        public DataAccess dataAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess = Global.DataAccess;
            if (!IsPostBack)
            {
                int userId = 1;
                LoadOrderDetails(userId);
            }

        }
        public void LoadOrderDetails(int userID)
        {

            var orderDetails = dataAccess.GetOrderDetails(userID);
            if (orderDetails.Count > 0)
            {
                
                gvOrderDetails.DataSource = orderDetails;
                gvOrderDetails.DataBind();
                lblTotalAmount.Text = (orderDetails.Sum(a=>a.TotalAmount).ToString("C"));
            }
        }
    }
}

    