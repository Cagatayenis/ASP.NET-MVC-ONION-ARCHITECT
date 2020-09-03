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
    public class RestaurantController : Controller
    {
        // GET: Administrator/Restaurant

        RestaurantService rs = new RestaurantService();
        public ActionResult Index()
        {
            return View(rs.GetAll());
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Restaurant item, HttpPostedFileBase fluResim)
        {
           
            if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Restaurant, out sonuc);
                if (sonuc)
                {
                    item.imagePath = fileResult;
                }
                else
                {
                    ViewBag.Mesaj = fileResult;
                }
                bool eklemeSonucu = rs.Add(item);
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
            Restaurant grestorant = rs.GetbyID(id);
            return View(rs.GetbyID(id));
        }
        [HttpPost]
        public ActionResult Update(Restaurant item, HttpPostedFileBase fluResim)
        { 
            Restaurant guncellenen = rs.GetbyID(item.ID);
            guncellenen.Name = item.Name;
            guncellenen.Working_Hour = item.Working_Hour;
            guncellenen.End_Time = item.End_Time;
            guncellenen.Service_Time = item.Service_Time;
            guncellenen.imagePath = item.imagePath;
            guncellenen.Packagefee = item.Packagefee;
            guncellenen.Promotionalinformation = item.Promotionalinformation;
            guncellenen.WarningandInformation = item.WarningandInformation;

            if (ModelState.IsValid)
            {
                if (fluResim != null)
                {
                    bool sonuc;
                    string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.Restaurant, out sonuc);
                    if (sonuc)
                    {
                        guncellenen.imagePath = fileResult;

                    }
                }
                bool eklemeSonucu = rs.Update(guncellenen);
                if (eklemeSonucu)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = $"Ürün ekleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin.";
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
            rs.Remove(id);
            return RedirectToAction("Index");
        }
    }
}