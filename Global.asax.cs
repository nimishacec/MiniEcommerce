using ExpenseManagementApp.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ExpenseManagementApp
{
    public class Global : HttpApplication
    {
        public static DataAccess DataAccess;
        void Application_Start(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            DataAccess = new DataAccess(connectionString);
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}