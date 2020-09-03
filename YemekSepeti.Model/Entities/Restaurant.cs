using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class Restaurant : CoreEntity
    {
        public string Name { get; set; }
        public DateTime Working_Hour { get; set; }
        public DateTime End_Time { get; set; }
        public string Service_Time { get; set; }
        public string imagePath { get; set; } //Bos Gecilebilir.
        public string Packagefee { get; set; }
        public string Promotionalinformation { get; set; }//Bos gecilebilir.
        public string WarningandInformation { get; set; }//Bos Gecilebilir

        public virtual List<Address> Addresses { get; set; }

        public virtual List<RestorantKategori> RestorantKategoris { get; set; }

        public virtual List<Meal> Meals { get; set; }
        public virtual List<ShoppingCart> ShoppingCarts { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
