using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Map;
using YemekSepeti.Model.Entities;

namespace YemekSepeti.Model.Map
{
    class AddressMap:CoreMap<Address>
    {
        public AddressMap()
        {
            ToTable("dbo.Addresss");
            Property(m => m.FullAddress).HasMaxLength(900).IsRequired();
        }
    }
}
