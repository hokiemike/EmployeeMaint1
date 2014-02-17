using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMaint.Data.Entities;

using NHibernate;
using NHibernate.Linq;

using RSUI.Data.Domain.Utils;

namespace EmployeeMaint.Data.Repository
{
    public class EmpRepository : EmployeeMaint.Data.Repository.IEmpRepository
    {

        public ISession CurrentSession { get { return NHibernateConfiguration.CurrentSession; } }

        public IQueryable<Employee> GetAllEmployees()
        {


            return CurrentSession.Query<Employee>();
               
                

            //q.SetFirstResult(20);
            //q.SetMaxResults(100);
            //return query;

          

        }

       

        public Employee GetEmployeeById(int id)
        {
            return CurrentSession.Get<Employee>(id);
        }
    }


}
