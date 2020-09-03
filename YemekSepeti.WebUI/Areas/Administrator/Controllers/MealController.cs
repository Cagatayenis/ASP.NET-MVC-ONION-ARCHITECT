using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;
using YemekSepeti.WebUI.Models;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class MealController : Controller
    {
        // GET: Administrator/Meal
        RestaurantService rs = new RestaurantService();
        CategoryService cs = new CategoryService();
        MealService ms = new MealService();
        public ActionResult Index()
        {
            return View(ms.GetAll());
        }
        public ActionResult Insert()
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name");
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Meal item, HttpPostedFileBase fluResim)
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name", item.CategoryID);
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", item.RestaurantID);

            if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Meal, out sonuc);
                if (sonuc)
                {
                    item.imagePath = fileResult;
                }
                else
                {
                    ViewBag.Mesaj = fileResult;
                }
                bool eklemeSonucu = ms.Add(item);
                if (eklemeSonucu)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "Ekleme işlemi Sirasinda Bir Hata Olustu.";
                }


            }
            return View();
        }

        public ActionResult Update(Guid id)
        {
            Meal gyemek = ms.GetbyID(id);
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name", gyemek.CategoryID);
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", gyemek.RestaurantID);

            return View(ms.GetbyID(id));
        }

        [HttpPost]
        public ActionResult Update(Meal item, HttpPostedFileBase fluResim)
        {
            ViewBag.CategoryID = new SelectList(cs.GetActive(), "ID", "Name", item.RestaurantID);
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", item.RestaurantID);
            if (ModelState.IsValid)
            {
                if (fluResim != null)
                {
                    bool sonuc;
                    string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Meal, out sonuc);
                    if (sonuc)
                    {
                        item.imagePath = fileResult;

                    }
                }
                bool eklemeSonucu = ms.Update(item);
                if (eklemeSonucu)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = $"Yemek ekleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin.";
                }
            }
            else
            {
                ViewBag.Message = $"Lütfen girmiş olduğunuz bilgilerin eksiksiz ve doğru formatta olduğundan emin olun.";
            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            ms.Remove(id);
            return RedirectToAction("Index");
        }
    }
}