using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

using EmployeeMaint.Data.Repository;
using RSUI.Data.Domain.Utils;
using RSUI.Web;
using RSUI.Utils.Collection;
using EmployeeMaint1.Models;

namespace EmpMaintTestProject1
{
    [TestClass]
    public class EmpRepositoryTest : BaseRepoTest
    {
        
        
        [TestInitialize]
        public void Init()
        {
            Setup();

            TheRepository = new EmpRepository();

        }

        [TestCleanup]
        public void Destroy()
        {
            Shutdown();
        }

        public EmpRepository TheRepository { get; set; }

        [TestMethod]
        public void TestGetAll()
        {
            foreach (var e in TheRepository.GetAllEmployees())
            {
                Console.WriteLine(e.DisplayName + "  branch:{0}",e.Branch);
            }
        }

        [TestMethod]
        public void TestGetAllWithPagingAndProjection()
        {

            var pagedata = TheRepository.GetAllEmployees()
               .OrderBy(e => e.LastName)
               .Skip(40)
               .Take(30);
            //var projection = pagedata
            //    .Select(e => TheModelFactory.Create(e));

            foreach (var e in pagedata)
            {
                Console.WriteLine(e.DisplayName + "  branch:{0}", e.Branch);
            }
        }

        [TestMethod]
        public void TestGetAllShowOtherDepts()
        {
            foreach (var e in TheRepository.GetAllEmployees())
            {
                Console.WriteLine(e.DisplayName + "  branch:{0}", e.Branch);
                //if (e.OtherEmployeeDepartments != null)
                //{
                //    e.OtherEmployeeDepartments.Each(d => Console.WriteLine("  other dept:{0}", d));                   
                //}
            }
        }

       
    }
}
