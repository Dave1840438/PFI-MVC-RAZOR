using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCProject.Controllers
{
   public class UserController : Controller
   {
      [HttpGet]
      public ActionResult Login()
      {
         return View();
      }
      [HttpPost]
      public ActionResult Login(String Username, String Password)
      {
         Session["userValid"] = false;
         if (Username != "admin")
            TempData["Notice"] = "Nom d'usager incorrecte";
         else
            if (Password != "password")
               TempData["Notice"] = "Mot de passe incorrecte";
            else
            {
               Session["userValid"] = true;
               return Redirect("List");
            }
         return View();
      }

      public ActionResult List()
      {
         if (!(bool) Session["userValid"])
         {
            TempData["notice"] = "Vous devez être connecté!";
            return Redirect("/User/Login");
         }

         List<String> UserList = new List<string>();
         UserList.Add("Nicolas");
         UserList.Add("Julie");
         UserList.Add("Alain");
         UserList.Add("Martine");
         UserList.Add("Mélissa");
         UserList.Add("Dominic");

         return View(UserList);
      }
   }
}