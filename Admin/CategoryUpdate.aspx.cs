using ExpenseManagementApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagementApp.Admin
{
    public partial class CategoryUpdate : System.Web.UI.Page
    {
        public DataAccess dataAccess;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess = Global.DataAccess;
            if (!IsPostBack) // Ensures this runs only on the first load
            {
                if (Request.QueryString != null)
                {
                    int CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                    LoadCategory(CategoryID);
                }
            }
        }
    
    private void LoadCategory(int CategoryID)
    {       
        var categories = dataAccess.GetCategory(CategoryID);
            txtCategoryName.Text = categories.CategoryName;
            txtDescription.Text = categories.Description;

    }
        protected void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.ToString();
            string description = txtDescription.Text.ToString();
            int CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            if (string.IsNullOrEmpty(categoryName))
            {
                lblMessage.Text = "Category Name is required.";
                lblMessage.CssClass = "text-danger";
                return;
            }
            bool addcategory = dataAccess.UpdateCategory(categoryName, description, CategoryID);
            if (addcategory != false)
            {
                lblMessage.Text = "Category updated successfully!";
                lblMessage.CssClass = "text-success";

                // Optionally clear fields
                txtCategoryName.Text = string.Empty;
                txtDescription.Text = string.Empty;


            }
            else
            {
                lblMessage.Text = "Failed to update category.";
                lblMessage.CssClass = "text-danger";
            }
            Response.Redirect("Categories.aspx");
        }
    }
    
}