using NewsEffectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NewsEffectWeb.Controllers
{
    public class RemoveController : Controller
    {
        public static DRModel mymodel = new DRModel();

        [HttpPost]
        public void ButtonData(int userid, string password)
        {
           // return PartialView(mymodel.removalco(mymodel.userid, mymodel.password)
            mymodel.removalco(userid, password);
        }

        // GET: Remove
        public ActionResult DeleteAccount()
        {
            //mymodel.removalco(mymodel.userid, mymodel.password); is result of button catch Senior managers wishing to delete their accounts must log in correctly
            return View(mymodel);
        }
    }
}