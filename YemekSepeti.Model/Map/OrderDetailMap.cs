using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("OrderDetails");
            Property(m => m.Quantity).IsOptional();
            Property(m => m.Price).IsOptional();
            
        }
    }
}
