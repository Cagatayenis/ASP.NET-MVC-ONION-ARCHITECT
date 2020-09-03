using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class CountryMap : CoreMap<Country>
    {
        public CountryMap()
        {
            ToTable("dbo.Countrys");
            Property(m => m.CountryName).HasMaxLength(50).IsRequired();
        }
    }
}
