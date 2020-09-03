using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class RestaurantKategoriController : Controller
    {
        // GET: Administrator/RestaurantKategori

        RestaurantKategori rks = new RestaurantKategori();
        CategoryService cs = new CategoryService();
        RestaurantService rs = new RestaurantService();

        public ActionResult Index()
        {
            return View(rks.GetAll());
        }

        public ActionResult Insert()
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name");
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(RestorantKategori item)
        {
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", item.RestaurantID);
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name",item.CategoryID);
            if (ModelState.IsValid)
            {
                bool sonuc = rks.Add(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "Kategori Ekleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
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
            RestorantKategori guncelrk = rks.GetbyID(id);
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", guncelrk.RestaurantID);
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name", guncelrk.CategoryID);

            return View(rks.GetbyID(id));
        }
        [HttpPost]
        public ActionResult Update(RestorantKategori item)
        {
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", item.RestaurantID);
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name", item.CategoryID);
            if (ModelState.IsValid)
            {
                bool sonuc = rks.Update(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "Kategori Ekleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
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
            rks.Remove(id);
            return RedirectToAction("Index");
        }

    }
}