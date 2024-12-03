using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpenseManagementApp.DataBase;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Text;
using ExpenseManagementApp.Models;

namespace ExpenseManagementApp.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        public DataAccess dataAccess;
        PagedDataSource pds = new PagedDataSource();
        //  protected int currentPage;
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
            dataAccess = Global.DataAccess;
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
                if (Request.QueryString["deleteID"] != null)
                {
                    int categoryID = int.Parse(Request.QueryString["deleteID"]);
                    if (categoryID != 0)
                    {

                        DeleteCategory(categoryID);

                        LoadCategoryList();

                    }
                }

                LoadCategoryList(null);
            }

        }


        public void DeleteCategory(int categoryID)
        {

            var status = dataAccess.DeleteCategory(categoryID);
            if (status)

                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Category deleted successfully' );", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "StatusAlert", $"alert('Error occurred while deleting category');", true);

        }




        private void LoadCategoryList(List<Category> categories = null)
        {

            var catList = dataAccess.GetCategories();
            int totalRecords = catList.Count;
            pds.DataSource = catList;
            pds.AllowPaging = true;
            pds.PageSize = pageSize;
            pds.CurrentPageIndex = currentPage - 1; // Pages are zero-based


            rptJobs.DataSource = pds;
            rptJobs.DataBind();

            lnkPrevious.Enabled = !pds.IsFirstPage;
            lnkNext.Enabled = !pds.IsLastPage;

            lblPageInfo.Text = $"Page {currentPage} of {pds.PageCount}";
        }
        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            currentPage = Request.QueryString["page"] != null ? int.Parse(Request.QueryString["page"]) : 1;
            currentPage -= 1;
            Response.Redirect("Categories.aspx?page=" + currentPage);
        }

        // Event handler for the "Next" button click
        protected void lnkNext_Click(object sender, EventArgs e)
        {
            currentPage = Request.QueryString["page"] != null ? int.Parse(Request.QueryString["page"]) : 1;
            currentPage += 1;
            Response.Redirect("Categories.aspx?page=" + currentPage);
        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {

            Response.Redirect("AddCategory.aspx");
        }
        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                
                int categoryId = Convert.ToInt32(e.CommandArgument);

                
                Response.Redirect($"CategoryUpdate.aspx?CategoryID={categoryId}");
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
              
                int categoryId = Convert.ToInt32(e.CommandArgument);

                
                DeleteCategory(categoryId);

            }
        }
    }
}
