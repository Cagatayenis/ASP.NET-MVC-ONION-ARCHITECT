using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class Meal : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public decimal? Price { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public Guid RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual List<ShoppingCart> ShoppingCarts { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}