using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    class RestaurantMap : CoreMap<Restaurant>
    {
        public RestaurantMap()
        {
            ToTable("dbo.Restaurants");
            Property(m => m.Name).HasMaxLength(350).IsRequired();
            Property(m => m.Working_Hour).IsRequired();
            Property(m => m.End_Time).IsRequired();
            Property(m => m.Service_Time).HasMaxLength(50).IsRequired();
            Property(m => m.imagePath).HasMaxLength(259).IsOptional();
            Property(m => m.Packagefee).HasMaxLength(20).IsRequired();
            Property(m => m.Promotionalinformation).HasMaxLength(1000).IsOptional();
            Property(m => m.WarningandInformation).HasMaxLength(1000).IsOptional();
        }
    }
}
