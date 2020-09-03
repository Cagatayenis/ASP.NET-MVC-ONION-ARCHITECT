using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;

namespace YemekSepeti.Model.Entities
{
    public class AppUser:CoreEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsAdministrator { get; set; }

        public virtual List<Address> Address { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
