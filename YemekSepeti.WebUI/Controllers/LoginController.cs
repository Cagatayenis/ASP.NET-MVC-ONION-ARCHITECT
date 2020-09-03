using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AppUserService aus = new AppUserService();
        public ActionResult Login(AppUser item)
        {
            if(aus.Any(m=>m.Password==item.Password && m.UserName==item.UserName))
            {
                AppUser gelen = aus.GetByDefault(x => x.UserName == item.UserName);
                bool adminmi = gelen.IsAdministrator;
                if(adminmi)
                {
                    Session["LoginUser"] = gelen;
                    return RedirectToAction("Index", "Restaurant", new { area = "Administrator" });
                }
                else
                {
                    Session["LoginUser"] = gelen;
                    ViewBag.UserName = gelen.UserName;
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                //Hatali Kullanici Adi ve Şifre
            }
            return View();
        }

        public ActionResult Son()
        {
            Session["LoginUser"] = null;
            Session["sepetim"] = null;
            Session.Abandon();
            return View("/Views/Home/Index.cshtml");
        }

    }
}