using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using application1.Models;
using application1.Controllers;

namespace application1.Controllers
{
    public class actualController : Controller
    {
        // GET: actual
        AUGUSTprojectEntities db = new AUGUSTprojectEntities();

        string login;
        


        [HttpGet]
        public ActionResult LoginPage1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage1(USERinfo t)
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
                login = ANo;
                Session["LoginID"] = login;
                Session["ACCname"] = data.Name;

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
            var data = db.details.OrderByDescending(p => p.TransDate).Take(10);
            return View(data);

        }

        [HttpGet]
        public ActionResult StatmentDetail()
        {
          
            return View();
        }









        [HttpPost]
        public ActionResult StatmentDetail(String Command)
        {
          
           
            var radio = Request.Form["trans"].ToString();
            if (radio == "date")
            {
                DateTime from = DateTime.Parse(Request.Form["txtfrdate"].ToString());
                DateTime to = DateTime.Parse(Request.Form["txttodate"].ToString());
                var data = db.details.Where(x => x.TransDate >= from && x.TransDate <= to).ToList();

                Session["data"] = data;
                return View(data);
            }
            if (radio == "period")
            {
                string option = Request.Form["ddlmember"].ToString();
                if (option == "Last")
                {
                    DateTime today = DateTime.Now;
                    int year = today.Year;
                    int mi = today.Month;
                    int mi1 = today.Month - 1;
                    int d = today.Day;

                    string dt = year + "-" + mi + "-" + d;
                    string dt1 = year + "-" + mi1 + "-" + d;
                    DateTime test = DateTime.Parse(dt);
                    DateTime test1 = DateTime.Parse(dt1);
               
                    var data = db.details.Where(x => x.TransDate >= test1 && x.TransDate <= test).ToList();

                    Session["data"] = data;
                    return View(data);
                }
                if (option == "LastWeek")
                {
                    DateTime today = DateTime.Now;
                    int year = today.Year;
                    int mi = today.Month;
                    int d1, m1;
                    m1 = 0; d1 = 0;
                    int d = today.Day;
                    if (d < 8)
                    {

                        if (d == 1)
                        {
                            m1 = mi - 1;
                            d1 = 25;
                        }
                        if (d == 2)
                        {
                            m1 = mi - 1;
                            d1 = 26;
                        }
                        if (d == 3)
                        {
                            m1 = mi - 1;
                            d1 = 27;
                        }
                        if (d == 4)
                        {
                            m1 = mi - 1;
                            d1 = 28;

                        }
                        if (d == 5)
                        {
                            m1 = mi - 1;
                            d1 = 29;
                        }
                        if (d == 6)
                        {
                            m1 = mi - 1;
                            d1 = 30;
                        }
                        if (d == 7)
                        {
                            m1 = mi - 1;
                            d1 = 31;
                        }

                    }
                    else
                    {
                        d1 = d - 7;
                        m1 = mi;
                    }


                    string dt = year + "-" + mi + "-" + d;
                    string dt1 = year + "-" + m1 + "-" + d1;
                    DateTime test = DateTime.Parse(dt);
                    DateTime test1 = DateTime.Parse(dt1);
                    /*  var a = Request.Form["ddlmember"].ToString();
                       if (a == "Last")
                       {
                           var lastmonth = new DateTime(today.Year, today.Month - 1, 1);
                           //var data=db.Children.Where(x=>x.AccNo==)
                       }
                     */
                    var data = db.details.Where(x => x.TransDate >= test1 && x.TransDate <= test).ToList();

                    Session["data"] = data;
                    return View(data);
                }
                if (option == "Today")
                {
                    DateTime today = DateTime.Now;
               
                    var data = db.details.Where(x => x.TransDate ==today).ToList();

                    Session["data"] = data;
                    return View(data);
                }
               
            }

            return View();

        }
    }
}




    




       

        
    
