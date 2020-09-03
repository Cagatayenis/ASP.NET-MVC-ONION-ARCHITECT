using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class DistrictController : Controller
    {
        // GET: Administrator/District
        CountryService ilceservisi = new CountryService();
        DistrictService semtservisi = new DistrictService();

        public ActionResult Index()
        {
            return View(semtservisi.GetAll());
        }
        public ActionResult Insert()
        {
            ViewBag.CountryID = new SelectList(ilceservisi.GetActive(), "ID", "CountryName");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(District item)
        {
            ViewBag.CountryID = new SelectList(ilceservisi.GetActive(), "ID", "CountryName", item.CountryID);

            if (ModelState.IsValid)
            {
                bool sonuc = semtservisi.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "Semt Ekleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
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
            District gsemt = semtservisi.GetbyID(id);
            ViewBag.CountryID = new SelectList(ilceservisi.GetActive(), "ID", "CountryName", gsemt.CountryID);
            return View(semtservisi.GetbyID(id));
        }

        [HttpPost]
        public ActionResult Update(District item)
        {
            ViewBag.CountryID = new SelectList(ilceservisi.GetActive(), "ID", "CountryName", item.CountryID);
            if (ModelState.IsValid)
            {
                bool sonuc = semtservisi.Update(item);
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
            semtservisi.Remove(id);
            return RedirectToAction("Index");
        }
    }
}