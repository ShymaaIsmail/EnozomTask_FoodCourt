using DBModel.Configuration;
using DBModel.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.DBContext
{
    public class FoodCourtContext : DbContext
    {
        public FoodCourtContext()
            : base("name=FoodCourtDBConnectionString") 
        {
            //set db initializer settings
           // Database.SetInitializer(new FoodCourtDBInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FoodCourtContext, DBModel.Migrations.Configuration>("FoodCourtDBConnectionString"));

        }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Configure domain classes using its separate fluent api
            modelBuilder.Configurations.Add(new StoreEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
