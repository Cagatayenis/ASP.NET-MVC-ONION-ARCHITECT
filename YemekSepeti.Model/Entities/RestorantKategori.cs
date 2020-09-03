using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class RestorantKategori : CoreEntity
    {
        public string CategoryName { get; set; }

        public Guid RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
