using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class Country:CoreEntity
    {
        public string CountryName { get; set; }

        public Guid ProvinceID { get; set; }
        public virtual Province Province { get; set; }

        public virtual List<Address> Addresss { get; set; }
        public virtual List<District> Districts { get; set; }
    }
}
