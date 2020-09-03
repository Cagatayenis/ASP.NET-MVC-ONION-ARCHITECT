using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class CountryController : Controller
    {
        // GET: Administrator/Country
        ProvinceService ilservisi = new ProvinceService();
        CountryService ilceservisi = new CountryService();
        public ActionResult Index()
        {
            return View(ilceservisi.GetAll());
        }
        public ActionResult Insert()
        {
            ViewBag.ProvinceID = new SelectList(ilservisi.GetActive(), "ID", "ProvinceName");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Country item)
        {
            ViewBag.ProvinceID = new SelectList(ilservisi.GetActive(), "ID", "ProvinceName", item.ProvinceID);

            if (ModelState.IsValid)
            {
                bool sonuc = ilceservisi.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "İlçe Ekleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
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
            Country gilce = ilceservisi.GetbyID(id);
            ViewBag.ProvinceID = new SelectList(ilservisi.GetActive(), "ID", "ProvinceName", gilce.ProvinceID);
            return View(ilceservisi.GetbyID(id));
        }

        [HttpPost]
        public ActionResult Update(Country item)
        {
            ViewBag.ProvinceID = new SelectList(ilservisi.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            if (ModelState.IsValid)
            {
                bool sonuc = ilceservisi.Update(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "Mutfak Ekleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
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
            ilceservisi.Remove(id);
            return RedirectToAction("Index");
        }

    }
}