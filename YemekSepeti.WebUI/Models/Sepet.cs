using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.WebUI.Models
{
    public class Sepet
    {
        public Guid ID { get; set; }
        public Guid MealID { get; set; }
        public Guid RestaurantID { get; set; }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? Quantity { get; set; }

    }
}