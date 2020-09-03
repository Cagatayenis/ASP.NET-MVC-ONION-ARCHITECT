using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YemekSepeti.Core.Entity;
using YemekSepeti.Model.Entities;
using YemekSepeti.Model.Map;

namespace YemekSepeti.Model.Context
{
    public class YSContext : DbContext
    {
        public YSContext()
        {
            Database.Connection.ConnectionString = "Data Source=.\\SQLEXPRESS; Database=ProjeYemekSepeti; UID=sa; PWD=123";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new MealMap());
            modelBuilder.Configurations.Add(new RestaurantMap());
            modelBuilder.Configurations.Add(new RestorantKategoriMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new DistrictMap());
            modelBuilder.Configurations.Add(new ShoppingCartMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestorantKategori> RestorantKategoris { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }




        public override int SaveChanges()
        {
            var ModifiedEntities = ChangeTracker.Entries().Where(m => m.State == EntityState.Modified || m.State == EntityState.Added).ToList();
            DateTime datetime = DateTime.Now;
            string ip = HttpContext.Current.Request.UserHostAddress;

            foreach (var item in ModifiedEntities)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedIP = ip;
                            entity.CreatedDate = datetime;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedIP = ip;
                            entity.ModifiedDate = datetime;
                            break;
                    }
                }

            }
            return base.SaveChanges();
        }
    }
}
