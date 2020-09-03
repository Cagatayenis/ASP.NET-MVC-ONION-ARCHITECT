using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Context;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;

namespace YemekSepeti.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        AddressService AddressService = new AddressService();
        ProvinceService ilservisi = new ProvinceService();
        CountryService ilceservisi = new CountryService();
        DistrictService semtservisi = new DistrictService();
        RestaurantService rs = new RestaurantService();
        MealService ys = new MealService();
        public ActionResult Index()
        {
            ViewBag.ProvinceID = new SelectList(ilservisi.GetActive(),"ID", "ProvinceName");
            List<SelectListItem> lists = new List<SelectListItem>()
            {
                new SelectListItem(){Text = " Seçiniz", Value = "0"  }
            };

            ViewData["CountryID"] = lists;
            ViewData["DistrictID"] = lists;
            return View();
        }
        public JsonResult ilcebilgisi(Guid id)
        {
            var data = new SelectList(ilceservisi.GetDefault(m => m.ProvinceID == id), "ID", "CountryName");
            var ilk = new SelectListItem { Text = "Seçiniz", Value = "0" };
            List<SelectListItem> lists = new List<SelectListItem>();
            lists.Add(ilk);

            foreach (var item in data)
            {
                lists.Add(item);
            }
            ViewData["ProvinceID"] = lists;
            return Json(ViewData["ProvinceID"], JsonRequestBehavior.AllowGet);
        }
        public JsonResult Semtbilgisi(Guid id)
        {
            var data = new SelectList(semtservisi.GetDefault(m => m.CountryID == id), "ID", "DistrictName");
            var ilk = new SelectListItem { Text = "Seçiniz", Value = "0" };
            List<SelectListItem> lists = new List<SelectListItem>();
            lists.Add(ilk);

            foreach (var item in data)
            {
                lists.Add(item);
            }
            ViewData["CountryID"] = lists;
            return Json(ViewData["CountryID"], JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult RestaurantList(Guid id)
        {
            
            ViewBag.resto=rs.GetAll().Where(m => m.Addresses.Any(c => c.CountryID == id));         
            return View();
        }
        public ActionResult detailpage(Guid id)
        { 
            ViewBag.menu = ys.GetDefault(m => m.RestaurantID == id);
            return View();
        } 


    }
}