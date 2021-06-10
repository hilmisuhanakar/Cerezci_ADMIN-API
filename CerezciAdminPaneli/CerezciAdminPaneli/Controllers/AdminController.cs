using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model;

namespace CerezciAdminPaneli.Controllers
{
    public class AdminController : Controller
    {
        CerezciDbContext admin = new CerezciDbContext();

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(AdminInfo User)
        {
            var userDetails = admin.Admins.Where(x => x.UserName == User.UserName && x.Password == User.Password).FirstOrDefault();
            if (userDetails == null)
            {
                ViewBag.Hata = "Yanlış Kullanıcı";
                return View("LogIn", "Admin");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(User.UserName, false); //Cookie oluşturmak için
                //Session["Password"] = userDetails.Password;
                return RedirectToAction("Index", "Products");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Admin");
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}