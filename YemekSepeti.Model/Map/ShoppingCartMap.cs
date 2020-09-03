using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class ShoppingCartMap : CoreMap<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            ToTable("ShoppingCarts");
            Property(m => m.Quantity).IsOptional();
            Property(m => m.Name).IsOptional();
            Property(m => m.Price).HasColumnType("money").IsOptional();
            
        }

    }
}
