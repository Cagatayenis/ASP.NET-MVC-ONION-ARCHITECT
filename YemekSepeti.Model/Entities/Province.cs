using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class Province:CoreEntity
    {
        public string ProvinceName { get; set; }

         public virtual List<Address> Addresss { get; set; }
         public virtual List<Country> Countries { get; set; }

    }
}
