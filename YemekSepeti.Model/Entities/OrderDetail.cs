using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
   public class OrderDetail:CoreEntity
    {
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        

        public Guid? MealID { get; set; }
        public virtual Meal Meal { get; set; }

        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
    }
}
