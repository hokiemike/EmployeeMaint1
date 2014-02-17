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
    public abstract class BaseEmpApiController : ApiController
    {

        IEmpRepository _repo;
        ModelFactory _modelFactory;

        public BaseEmpApiController(IEmpRepository repo)
        {
          _repo = repo;
        }

        protected IEmpRepository EmpRepo
        {
          get
          {
            return _repo;
          }
        }

        protected ModelFactory TheModelFactory
        {
          get
          {
            if (_modelFactory == null)
            {
                _modelFactory = new ModelFactory(this.Request, EmpRepo);
            }
            return _modelFactory;
          }
        }

    }


}
