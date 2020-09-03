using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    public class MealMap:CoreMap<Meal>
    {
        public MealMap()
        {
            ToTable("Meals");
            Property(m => m.Name).HasMaxLength(200).IsRequired();
            Property(m => m.Description).HasMaxLength(200).IsOptional();
            Property(m => m.imagePath).HasMaxLength(250).IsOptional();
            Property(m => m.Price).HasColumnType("money").IsRequired();
        }
    }
}
