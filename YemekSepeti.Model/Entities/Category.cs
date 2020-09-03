using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class Category : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<RestorantKategori> RestorantKategoris { get; set; }

        public virtual List<Meal> Meals { get; set; }
    }
}
