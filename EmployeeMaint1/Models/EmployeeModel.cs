using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeMaint1.Models
{
    public class EmployeeModel
    {
        public string Url { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public string BranchDesc { get; set; }
        public IList<int> OtherDepts { get; set; }
    }
}