using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class RestorantKategoriMap:CoreMap<RestorantKategori>
    {
        public RestorantKategoriMap()
        {
            ToTable("RestorantKategoris");
            Property(m => m.CategoryName).IsOptional().HasMaxLength(150);
        }
    }
}
