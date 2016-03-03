using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsEffectProj
{
    public class Staff : Departments
    {
        public int employeeid { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public bool ismanager { get; set; }
        public string password { get; set; }
        //public int managerid { get; set; }
    }
}
