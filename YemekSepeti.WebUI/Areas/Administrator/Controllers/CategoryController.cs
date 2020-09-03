using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Administrator/Category
        CategoryService cs = new CategoryService();
        public ActionResult Index()
        {
            return View(cs.GetAll());
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Category item)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = cs.Add(item);
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

        public ActionResult Update(Guid id)
        {
            return View(cs.GetbyID(id));
        }

        [HttpPost]
        public ActionResult Update(Category item)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = cs.Update(item);
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
            cs.Remove(id);
            return RedirectToAction("Index");
        }


    }
}