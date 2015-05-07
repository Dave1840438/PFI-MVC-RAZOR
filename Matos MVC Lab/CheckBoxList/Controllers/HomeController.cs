using CheckBoxList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckBoxList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            List<CheckBoxData> items = new List<CheckBoxData>();
            items.Add(new CheckBoxData(false, "Rouge"));
            items.Add(new CheckBoxData(true, "Vert"));
            items.Add(new CheckBoxData(false, "Bleue"));
            items.Add(new CheckBoxData(false, "Blanc"));
            return View(items);
        }
        [HttpPost]
        public ActionResult List(List<CheckBoxData> items)
        {
            return View(items);
        }
    }
}