using ExpenseManagementApp.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementApp.Admin
{
    public partial class Addcategory : System.Web.UI.Page
    {
        public DataAccess dataAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess=Global.DataAccess;
            if (!IsPostBack)
            {
                
            }
        }
       
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                lblMessage.Text = "Category Name is required.";
                lblMessage.CssClass = "text-danger";
                return;
            }
            bool addcategory=dataAccess.Addcategory(categoryName, description);
          if (addcategory != false) {
                lblMessage.Text = "Category added successfully!";
                lblMessage.CssClass = "text-success";

                // Optionally clear fields
                txtCategoryName.Text = string.Empty;
                txtDescription.Text = string.Empty;


            }
            else
            {
                lblMessage.Text = "Failed to add category.";
                lblMessage.CssClass = "text-danger";
            }
            Response.Redirect("Categories.aspx");
        }
    }
}