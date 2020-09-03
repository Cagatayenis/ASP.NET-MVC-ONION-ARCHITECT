using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class DistrictMap : CoreMap<District>
    {
        public DistrictMap()
        {
            ToTable("dbo.Districts");
            Property(m => m.DistrictName).HasMaxLength(50).IsRequired();
        }
    }
}
