using MVC_MainSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MainSite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String UserName, String Password)
        {
            UsersModel users = new UsersModel(Session["MainDB"]);
            if (users.Exist(UserName))
            {
                if (users.Password == Password)
                {
                    TempData["Notice"] = "Vous êtes maintenant connecté...";
                    Session["UserValid"] = true;
                    return RedirectToAction("List", "Home");
                }
                else
                {
                    TempData["Notice"] = "Mot de passe incorrect...";
                }
            }
            else
                TempData["Notice"] = "Cet usager n'existe pas...";
            return View();
        }
        [HttpGet]
        public ActionResult Subscribe()
        {
            return View(new UsersModel());
        }
        [HttpPost]

        public ActionResult Subscribe(UsersModel newUser)
        {
            UsersModel users = new UsersModel(Session["MainDB"]);
            if (!String.IsNullOrEmpty(newUser.UserName))
            {
                if (!users.Exist(newUser.UserName))
                {
                    if (!String.IsNullOrEmpty(newUser.Password))
                    {
                        users.UserName = newUser.UserName;
                        users.Password = newUser.Password;
                        users.FullName = newUser.FullName;
                        users.EMail = newUser.EMail;

                        if (Request.Files.Count > 0)
                        {
                            var file = Request.Files[0];
                            if (file != null && file.ContentLength > 0)
                            {
                                users.Avatar = Guid.NewGuid().ToString();
                                file.SaveAs(Server.MapPath(@"~\Avatars\") + users.Avatar + ".png");
                            }
                        }
                        users.Insert();
                        return RedirectToAction("Index", "Home"); ;
                    }
                    else
                    {
                        TempData["Notice"] = "Le mot de passe est vide...";
                    }
                }
                else
                {
                    TempData["Notice"] = "Cet usager existe déjà...";
                }
            }
            return View(newUser);
        }
        public ActionResult List()
        {
            ViewBag.Message = "Liste des usagers";
            UsersModel users = null;

            if (!(bool)Session["UserValid"])
                TempData["Notice"] = "Vous n'êtes pas connecté...";
            else
            {
                users = new UsersModel(Session["MainDB"]);
            }
            return View(users);
        }
        [HttpGet]
        public ActionResult Edit(String ID)
        {
            UsersModel users = new UsersModel(Session["MainDB"]);
            users.SelectByID(ID);
            users.Next();
            users.EndQuerySQL();

            return View(users);
        }

        [HttpPost]
        public ActionResult Edit(UsersModel users)
        {
            // users est une nouvelle instance peuplée par le formulaire
            UsersModel updatedUser = new UsersModel(Session["MainDB"]);
            updatedUser.SelectByID(users.ID.ToString()); 
            updatedUser.EndQuerySQL();

            updatedUser.FullName = users.FullName;
            updatedUser.Password = users.Password;
            updatedUser.EMail = users.EMail;

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    if (!String.IsNullOrEmpty(updatedUser.Avatar))
                        System.IO.File.Delete(Server.MapPath(@"~\Avatars\") + updatedUser.Avatar + ".png");
                    updatedUser.Avatar = Guid.NewGuid().ToString();
                    file.SaveAs(Server.MapPath(@"~\Avatars\") + updatedUser.Avatar + ".png");
                }
            }
            updatedUser.Update();
            return RedirectToAction("List", "Home");
        }

        public ActionResult Delete(String ID)
        {
            UsersModel users = new UsersModel(Session["MainDB"]);
            users.DeleteRecordByID(ID);
            return RedirectToAction("List", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Démonstration MVC";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Page - Contact";

            return View();
        }
    }
}