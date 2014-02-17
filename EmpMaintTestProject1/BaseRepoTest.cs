using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSUI.Data.Domain.Utils;
using RSUI.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMaintTestProject1
{
    public class BaseRepoTest
    {
        
        protected void Setup()
        {
            ConfigureNHibernate();
            ConfigureLog4Net();

        }

        protected void Shutdown()
        {
            SessionManager.CloseSession();
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
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(@"log4net.config.xml"));
        }
    }
}
