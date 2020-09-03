using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class ShoppingCart : CoreEntity
    {
       
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }

        public Guid RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public Guid? MealID { get; set; }
        public virtual Meal Meal { get; set; }

        public Guid? AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
