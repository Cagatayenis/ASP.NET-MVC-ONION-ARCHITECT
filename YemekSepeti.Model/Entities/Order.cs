using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class Order:CoreEntity
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public DateTime? OrderDate { get; set; }
        public DateTime? SendingDate { get; set; }
       
        public  string CustomerAddress { get; set; }
        public Guid RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }


        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
