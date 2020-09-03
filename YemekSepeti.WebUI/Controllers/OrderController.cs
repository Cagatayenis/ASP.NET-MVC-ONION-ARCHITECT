using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSepeti.Model.Entities;
using YemekSepeti.Service.Option;
using YemekSepeti.WebUI.Models;

namespace YemekSepeti.WebUI.Controllers
{
    public class OrderController : Controller
    {
        AppUser kullanici;
        Restaurant rs = new Restaurant();
        OrderService os = new OrderService();
        OrderDetailService ods = new OrderDetailService();
        // GET: Order
        public ActionResult Index()
        {
            
            if (Session["LoginUser"] != null)
            {
                return View("/Views/Order/Index.cshtml");
            }
            else
            {
               
            }
            return View("/Views/Home/Index.cshtml");
            
        }
        public ActionResult SiparisDetay()
        {
            ViewBag.Detail = ods.GetActive();
            return View();
        }
        
        public ActionResult Insert(Order item,Sepet item1)
        {
          
            List<Sepet> sepetim = (List<Sepet>)Session["sepetim"];
            if (Session["LoginUser"]!=null)
            {
                
                kullanici = (AppUser)Session["LoginUser"];
                Order siparis = new Order();
                siparis.AppUserID = kullanici.ID;
                siparis.OrderDate = DateTime.Now;
                siparis.SendingDate = DateTime.Now.AddMinutes(30);
                siparis.CustomerAddress = item.CustomerAddress;
                foreach (Sepet x in (List<Sepet>)Session["sepetim"])
                {
                    siparis.RestaurantID = x.RestaurantID;
                }

                os.Add(siparis);

                foreach (Sepet item3 in sepetim)
                {
                    OrderDetail detay = new OrderDetail();
                    detay.OrderID = siparis.ID;
                    detay.MealID = item3.MealID;
                    detay.Price = item3.Price;
                    detay.Quantity = (short)item3.Quantity;

                    ods.Add(detay);
                    siparis.OrderDetails.Add(detay);
                }
                //Session["sepetim"] = null;
                return RedirectToAction("SiparisDetay","Order");
            }
            return View();
        }
    }
}