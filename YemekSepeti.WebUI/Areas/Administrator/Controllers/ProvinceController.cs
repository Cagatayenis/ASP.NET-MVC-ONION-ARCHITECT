using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class ProvinceController : Controller
    {
        // GET: Administrator/Province
        ProvinceService ilservisi = new ProvinceService();
        public ActionResult Index()
        {
            return View(ilservisi.GetAll());
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Province item)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = ilservisi.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "İL Ekleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
                }
            }
            else
            {
                ViewBag.Mesaj = "Girmiş oldugunuz bilgiler hatali formattta veya eksiktir.Lütfen girmeye çaliştiğiniz verileri kontrol edin.";
            }
            return View();
        }

        public ActionResult Update(Guid id)
        {
            return View(ilservisi.GetbyID(id));
        }

        [HttpPost]
        public ActionResult Update(Province item)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = ilservisi.Update(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "İl Güncelleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
                }
            }
            else
            {
                ViewBag.Mesaj = "Girmiş oldugunuz bilgiler hatali formattta veya eksiktir.Lütfen girmeye çaliştiğiniz verileri kontrol edin.";
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            ilservisi.Remove(id);
            return RedirectToAction("Index");
        }
    }
}