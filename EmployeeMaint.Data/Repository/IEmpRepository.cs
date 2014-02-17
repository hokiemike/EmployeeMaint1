using EmployeeMaint.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeMaint.Data.Repository
{
    public interface IEmpRepository
    {
        IQueryable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
    }
}
