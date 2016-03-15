using NewsEffectDatabaseConn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsEffectWeb.Models
{
    public class DRModel
    {
        public int userid { get; set; }
        public string password { get; set; }

        //public DRModel()
        //{}
        public void removalco(int guserid, string gpassword)
        {
            DatabaseRepository datarepo = new DatabaseRepository();
            if (datarepo.login(userid, password) == true)
            {
                datarepo.removecompany(userid);
            }
        }
    }
}