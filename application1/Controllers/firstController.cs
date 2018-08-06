using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using application1.Models;
using application1.Controllers;


namespace application1.Controllers
{
    /*public class firstController : Controller
    {

        AUGUSTprojectEntities db = new AUGUSTprojectEntities();



        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(USERinfo t)
        {
            string ANo = Request.Form["txtnumber"].ToString();
            string Pass = Request.Form["txtpass"].ToString();
            var data = db.USERinfoes.Where(x => x.AccNo == ANo && x.Password == Pass).SingleOrDefault();
            if (data == null)
            {
                ModelState.AddModelError("", "Login Inuccessful");
            }
            else
            {
                ModelState.AddModelError("", "Login Successful");
                return RedirectToAction("Links");
            }


            return View();
        }
        public ActionResult Links()
        {
            return View();
        }

        public ActionResult MiniStatement()
        {
            var data = db.details.OrderByDescending(p => p.TransDate).Take(2);
            return View(data);

        }
     

    }*/
}
    
