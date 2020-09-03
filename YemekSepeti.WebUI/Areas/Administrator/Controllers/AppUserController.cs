using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class AppUserController : Controller
    {
        // GET: Administrator/AppUser
        AppUserService aus = new AppUserService();

        public ActionResult Index()
        {
            return View(aus.GetAll());
        }
        public ActionResult Insert()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Insert(AppUser item)
        { 
            if (ModelState.IsValid)
            {
                bool sonuc = aus.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Kullanıcı ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Kullanıcı ekleme işleminde bir hata oluştu";
            }
            return View();
        }

        public ActionResult Update(Guid id)
        {
            return View(aus.GetbyID(id));
        }
        [HttpPost]
        public ActionResult Update(AppUser item)
        {
            AppUser gelen = aus.GetbyID(item.ID);
            gelen.Name = item.Name;
            gelen.SurName = item.SurName;
            gelen.UserName = item.UserName;
            gelen.EmailAddress = item.EmailAddress;
            gelen.Phone = item.Phone;
            gelen.IsAdministrator = item.IsAdministrator;
            
            bool sonuc = aus.Update(gelen);
            if (sonuc)
            {
                ViewBag.Message = "Güncelleme Başarılı";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Güncelleme Başarısız";

            }
            return View();
        }
        
        public ActionResult Delete(Guid id)
        {
            aus.Remove(id);
            return RedirectToAction("Index");
        }

    }
}