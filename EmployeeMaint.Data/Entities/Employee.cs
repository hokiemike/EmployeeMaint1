using System;
using System.Collections.Generic;
using System.Linq;

using RSUI.Data.Domain.Utils;
using RSUI.Utils.Collection;



namespace EmployeeMaint.Data.Entities
{

    public class Employee
    {
       
       

        #region Public Properties

        public virtual int Id  { get; set; } 
        public virtual string UserProfile   { get; set; }
        private char? ActiveCode { get; set; }
        public virtual string LastName {get; set;}
        public virtual string FirstName { get; set; }
        public virtual string MiddleName  { get; set; }
        public virtual string Prefix  { get; set; }
        public Branch Branch { get; set; }
        public virtual int? Extension { get; set; }
        public virtual int? DepartmentNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual decimal? PaymentAuthority { get; set; }
        public virtual int? EmployeeTypeKey { get; set; }
        public virtual bool IsExempt { get; set; }
        public virtual bool IsOnPayroll { get; set; }
        public virtual int? DefaultUnderwriter { get; set; }


        public virtual bool IsExecutive { get; set; }

        public virtual Employee DefaultAssistant { get; set; }

        public virtual string Initials { get; set; }
        public virtual string Signature { get; set; }

        public virtual ICollection<int> OtherEmployeeDepartments { get; set; }


        #endregion

        public bool IsInDepartment(int deptNum)
        {
            if (this.DepartmentNumber == deptNum)
                return true;

            return (OtherEmployeeDepartments != null && OtherEmployeeDepartments.Contains(deptNum));
        }

        public virtual bool IsUnderwriter
        {
            get { return (EmployeeTypeKey == 1); }
        }
        
           
       
        
       

        public virtual bool IsActive
        {
            get { return Converter.ActiveInactiveToBool(ActiveCode); }
            set { ActiveCode = Converter.BoolToActiveInactive(value); }
        }

  
        

        public virtual string FullName
        {
            get
            {
                var lastname = (LastName == null || LastName.Trim().Equals(string.Empty)) ? String.Empty : LastName;
                var firstname = (FirstName == null) ? String.Empty : FirstName;
                
                return lastname + (lastname.Equals(string.Empty) ? string.Empty : ", ") + firstname;
            }
        }


        public virtual string DisplayName
        {
            get
            {
                var firstname = (FirstName == null) ? String.Empty : FirstName;
                var lastname = (LastName == null) ? String.Empty : LastName;
                return firstname + " " + lastname;
            }
        }

       

        
        

        public override string ToString()
        {
            return string.Format("Employee [{0}]: {1}", Id, FullName);
        }
    }
}
