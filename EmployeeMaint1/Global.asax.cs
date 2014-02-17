using RSUI.Data.Domain.Utils;
using RSUI.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmployeeMaint1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(IocConfig.RegisterIoc);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureNHibernate();
            ConfigureLog4Net();

            


        }


        private void ConfigureNHibernate()
        {
            var connstr = ConfigurationManager.ConnectionStrings["EmployeeMaint.Settings.DEV3ConnectionString"].ConnectionString;
            NHibernateConfiguration.InitializeNHibernate(connstr);

            //force bind of session into CurrentSessionContext
            SessionManager.BindCurrentSession();


        }

        private void ConfigureLog4Net()
        {
            string filePath = Server.MapPath(".");
            var fileInfo = new System.IO.FileInfo(filePath + @"\log4net.config.xml");
            log4net.Config.XmlConfigurator.Configure(fileInfo);
        }
    }
}
