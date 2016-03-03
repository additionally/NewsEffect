using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsEffectProj
{
    public class DatabaseReader
    {
        private List<Companies> companylist;
        public virtual List<Companies> ReadDatabase()
        {
            return companylist;
        }
    }
}
