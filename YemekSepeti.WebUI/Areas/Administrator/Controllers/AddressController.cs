using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Areas.Administrator.Controllers
{
    public class AddressController : Controller
    {
        // GET: Administrator/Address
        AddressService adresservice = new AddressService();
        ProvinceService ilservice = new ProvinceService();
        CountryService ilceservice = new CountryService();
        DistrictService semtservice = new DistrictService();
        RestaurantService rs = new RestaurantService();

        public ActionResult Index()
        {

            return View(adresservice.GetAll());
        }

        public ActionResult Insert()
        {
            ViewBag.ProvinceID = new SelectList(ilservice.GetActive(), "ID", "ProvinceName");
            ViewBag.CountryID = new SelectList(ilceservice.GetActive(), "ID", "CountryName");
            ViewBag.DistrictID = new SelectList(semtservice.GetActive(), "ID", "DistrictName");
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Address item)
        {
            ViewBag.ProvinceID = new SelectList(ilservice.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.CountryID = new SelectList(ilceservice.GetActive(), "ID", "CountryName", item.CountryID);
            ViewBag.DistrictID = new SelectList(semtservice.GetActive(), "ID", "DistrictName", item.DistrictID);
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name",item.RestaurantID);
            if (ModelState.IsValid)
            {
                bool sonuc = adresservice.Add(item);
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
            Address gadres = adresservice.GetbyID(id);
            ViewBag.ProvinceID = new SelectList(ilservice.GetActive(), "ID", "ProvinceName", gadres.ProvinceID);
            ViewBag.CountryID = new SelectList(ilceservice.GetActive(), "ID", "CountryName", gadres.CountryID);
            ViewBag.DistrictID = new SelectList(semtservice.GetActive(), "ID", "DistrictName", gadres.DistrictID);
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", gadres.RestaurantID);

            return View(adresservice.GetbyID(id));
        }

        [HttpPost]
        public ActionResult Update(Address item)
        {
            ViewBag.ProvinceID = new SelectList(ilservice.GetActive(), "ID", "ProvinceName", item.ProvinceID);
            ViewBag.CountryID = new SelectList(ilceservice.GetActive(), "ID", "CountryName", item.CountryID);
            ViewBag.DistrictID = new SelectList(semtservice.GetActive(), "ID", "DistrictName", item.DistrictID);
            ViewBag.RestaurantID = new SelectList(rs.GetActive(), "ID", "Name", item.RestaurantID);
            if (ModelState.IsValid)
            {
                bool sonuc = adresservice.Update(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "Adres Güncelleme işlemi Sirasinda bir hata olustu.Lütfen daha sonra tekrar deneyin.";
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
            adresservice.Remove(id);
            return RedirectToAction("Index");
        }

    }
}