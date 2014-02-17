using EmployeeMaint.Data.Entities;
using EmployeeMaint.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;


namespace EmployeeMaint1.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private IEmpRepository _repo;
        public ModelFactory(HttpRequestMessage request, IEmpRepository repo)
        {
            _urlHelper = new UrlHelper(request);
            _repo = repo;
        }

        public EmployeeModel Create(Employee emp)
        {
            return new EmployeeModel()
            {
                Url = _urlHelper.Link("Employee", new { id = emp.Id }),
                FullName = emp.FullName,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                MiddleName = emp.MiddleName,
                EmailAddress = emp.EmailAddress,
                BranchDesc = ( emp.Branch != null ? emp.Branch.BranchDesc : String.Empty ),
                OtherDepts = (emp.OtherEmployeeDepartments != null ?  emp.OtherEmployeeDepartments.ToList() : null)

            };
        }

       

        
    }
}