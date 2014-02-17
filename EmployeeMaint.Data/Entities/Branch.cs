using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaint.Data.Entities
{
    public class Branch 
    {
        
        #region convenience constants
        public const int ATLANTAKEY = 100;
        public const int LAKEY = 200;
        private const int NJKEY = 300;
        private const int CHERRYHILLKEY = 900;

        #endregion

       
        public virtual int Id {get; set;}
        public virtual string BranchDesc {get; set;}

        public virtual bool IsAtlanta
        {
            get
            {
                return this.Id == ATLANTAKEY;
            }
        }

        public virtual bool IsLA
        {
            get
            {
                return this.Id == LAKEY;
            }
        }

    }
}
