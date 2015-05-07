using PartialViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewDemo.Controllers
{
    public class CurrencyController : Controller
    {
        [HttpGet]
        public ActionResult Show()
        {
            return View(new Currency());
        }
       
        public PartialViewResult ShowCurrency()
        {

            return PartialView("CurrencyPartial", new Currency());
        }
    }
}