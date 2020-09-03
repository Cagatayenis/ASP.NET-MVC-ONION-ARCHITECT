using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class Address:CoreEntity
    {
        public string FullAddress { get; set; }

         public Guid RestaurantID { get; set; }
         public virtual Restaurant Restaurant { get; set; }

         public Guid? ProvinceID { get; set; }
         public virtual Province Province { get; set; }

        public Guid? CountryID { get; set; }
        public virtual Country Country { get; set; }

        public Guid? DistrictID { get; set; }
        public virtual District District { get; set; }

        public Guid? AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
