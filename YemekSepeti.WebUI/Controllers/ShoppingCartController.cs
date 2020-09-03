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


    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        ShoppingCartService scs = new ShoppingCartService();
        MealService ms = new MealService();
        List<Sepet> sepetim;
        Sepet sepet = new Sepet();
        //ShoppingCart siparis;

        public PartialViewResult _SepetYeri()
        {
            if (Session["sepetim"] != null)
                return PartialView((List<Sepet>)Session["sepetim"]);
            else 
                return PartialView();
        }
        public ActionResult AddtoCart(Guid id, string islem)
        {
            AppUser gelen = (AppUser)Session["LoginUser"];
            Meal sepeteEklenenUrun = ms.GetbyID(id);

            //if (Session["LoginUser"] != null)
            //{
            //    siparis.AppUserID = gelen.ID;
            //    siparis.MealID = sepeteEklenenUrun.ID;
            //    siparis.RestaurantID = sepeteEklenenUrun.RestaurantID;
            //    siparis.Name = sepeteEklenenUrun.Name;
            //    siparis.Price = sepeteEklenenUrun.Price;
            //    siparis.Quantity = 1;

            //    bool sonuc = scs.Add(siparis);
            //    if (sonuc)
            //    {
            //        ViewBag.mesaj = "Yemek Eklendi.";
            //        return RedirectToAction("detailpage", "Home", new { id = siparis.RestaurantID });
            //    }
            //    else
            //    {
            //        ViewBag.mesaj = "Yemek Eklendi.";
            //    }
            //}
            if (Session["sepetim"] == null)
                sepetim = new List<Sepet>();
            else
                sepetim = (List<Sepet>)Session["sepetim"];
            if (sepetim.Count < 1 || sepetim.FirstOrDefault(x => x.MealID == sepeteEklenenUrun.ID) == null)
            { 
                sepet.MealID = sepeteEklenenUrun.ID;
                sepet.Name = sepeteEklenenUrun.Name;
                sepet.Price = sepeteEklenenUrun.Price;
                sepet.Quantity = 1;
                sepetim.Add(sepet);
                if (Session["LoginUser"] != null)
                {
                    ShoppingCart siparis = new ShoppingCart();
                    siparis.AppUserID = gelen.ID;
                    siparis.MealID = sepeteEklenenUrun.ID;
                    siparis.RestaurantID = sepeteEklenenUrun.RestaurantID;
                    siparis.Name = sepeteEklenenUrun.Name;
                    siparis.Price = sepeteEklenenUrun.Price;
                    siparis.Quantity = 1;

                    bool sonuc = scs.Add(siparis);
                    if (sonuc)
                    {
                        ViewBag.mesaj = "Yemek Eklendi.";
                        RedirectToAction("_SepetYeri");
                    }
                    else
                    {
                        ViewBag.mesaj = "Yemek Eklendi.";
                    }
                }
            }
            else
            {
                switch (islem)
                {
                    case "arti":
                        {
                            if (Session["LoginUser"]!=null)
                            {
                                ShoppingCart guncelle = scs.GetByDefault(m => m.MealID == sepeteEklenenUrun.ID);
                                guncelle.Quantity++;
                                guncelle.Price = sepeteEklenenUrun.Price * guncelle.Quantity;
                                bool sonuc = scs.Update(guncelle);
                                if(sonuc)
                                {
                                    ViewBag.mesaj = "Yemek Eklendi.";
                                    RedirectToAction("_SepetYeri");
                                }
                            }
                            Sepet guncellencek = sepetim.FirstOrDefault(m => m.MealID == sepeteEklenenUrun.ID);
                            guncellencek.Quantity++;
                            guncellencek.Price = guncellencek.Quantity * sepeteEklenenUrun.Price;
                            return RedirectToAction("_SepetYeri");
                        }
                    case "eksi":
                        {
                            if (Session["LoginUser"] != null)
                            {
                                ShoppingCart guncelle = scs.GetByDefault(m => m.MealID == sepeteEklenenUrun.ID);
                                guncelle.Quantity--;
                                guncelle.Price = sepeteEklenenUrun.Price * guncelle.Quantity;
                                bool sonuc = scs.Update(guncelle);
                                if (sonuc)
                                {
                                    ViewBag.mesaj = "Yemek Eklendi.";
                                    RedirectToAction("_SepetYeri");
                                }
                            }

                            Sepet sil = sepetim.FirstOrDefault(m => m.MealID == sepeteEklenenUrun.ID);
                            sil.Quantity--;
                            sil.Price = sil.Quantity * sepeteEklenenUrun.Price;
                            
                            if (sil.Quantity < 1)
                            {
                                sepetim.Remove(sil);
                                if (sepetim.Count == 0)
                                {
                                    Session["sepetim"] = null;
                                }
                            }
                            return RedirectToAction("_SepetYeri");
                        }


                }
            }

            sepet.RestaurantID = sepeteEklenenUrun.RestaurantID;
            Session["sepetim"] = sepetim;


            return RedirectToAction("detailpage", "Home", new { id = sepet.RestaurantID });
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}