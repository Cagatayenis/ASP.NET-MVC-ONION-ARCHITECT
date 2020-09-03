using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class CategoryMap : CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            Property(m => m.Name).HasMaxLength(50).IsRequired();
            Property(m => m.Description).HasMaxLength(150).IsOptional();
        }
    }
}
