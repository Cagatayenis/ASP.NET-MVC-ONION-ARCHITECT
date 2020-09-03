using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
            Property(m=>m.OrderDate).IsOptional();
            Property(m => m.SendingDate).IsOptional();
            Property(m => m.CustomerAddress).IsOptional();
        }
    }
}
