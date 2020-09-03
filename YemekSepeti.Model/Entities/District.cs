using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class District:CoreEntity
    {
        public string DistrictName { get; set; }


        public Guid CountryID { get; set; }
        public virtual Country Country { get; set; }


        public virtual List<Address> Addresss { get; set; }
    }
}
