using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class ProvinceMap : CoreMap<Province>
    {
        public ProvinceMap()
        {
            ToTable("dbo.Provinces");
            Property(m => m.ProvinceName).HasMaxLength(25).IsRequired();
        }
    }
}
