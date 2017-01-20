namespace DBModel.Migrations
{
    using DBModel.DBContext;
    using DBModel.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodCourtContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DBModel.DBContext.FoodCourtContext";
        }

        protected override void Seed(FoodCourtContext context)
        {
            //  This method will be called after migrating to the latest version.
            populateDefaultStores(context);
        }
        private void populateDefaultStores(FoodCourtContext context)
        {
            IList<Store> defaultStores = new List<Store>();

            defaultStores.Add(new Store() { StoreName = "Store 1", StoreDescription = "First Store", StoreLogo = "defaultImage.jpg" });
            defaultStores.Add(new Store() { StoreName = "Store 2", StoreDescription = "Second Store", StoreLogo = "defaultImage.jpg" });
            defaultStores.Add(new Store() { StoreName = "Store 3", StoreDescription = "Third Store", StoreLogo = "defaultImage.jpg" });
            defaultStores.Add(new Store() { StoreName = "Store 4", StoreDescription = "Third Store", StoreLogo = "defaultImage.jpg" });

            foreach (Store std in defaultStores)
            {
                // use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.
                context.Stores.AddOrUpdate(p => p.StoreName, std);
            }
        }
    }
}
