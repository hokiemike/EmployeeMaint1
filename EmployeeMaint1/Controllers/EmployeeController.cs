using EmployeeMaint.Data.Entities;
using EmployeeMaint.Data.Repository;
using EmployeeMaint1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeMaint1.Controllers
{
    public class EmployeeController : BaseEmpApiController
    {

        public EmployeeController(IEmpRepository repo) : base(repo)
        {
        }
     

        // GET api/<controller>
        public IEnumerable<EmployeeModel> Get()
        {
            var pagedata = EmpRepo.GetAllEmployees()
                .Where( e => e.OtherEmployeeDepartments.Count > 0)
                .OrderBy(e => e.LastName)
                //.Skip(40)
                .Take(30)
                .ToList();
            var projection = pagedata
                .Select(e => TheModelFactory.Create(e));       

            return projection;
        }

        // GET api/<controller>/5
        public EmployeeModel Get(int id)
        {
            return TheModelFactory.Create(EmpRepo.GetEmployeeById(id));
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}