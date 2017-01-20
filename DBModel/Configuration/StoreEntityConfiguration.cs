using DBModel.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Configuration
{
    public class StoreEntityConfiguration : EntityTypeConfiguration<Store>
    {
        public StoreEntityConfiguration()
        {

            this.ToTable("Store");

            this.HasKey<int>(s => s.StoreID);


            this.Property(p => p.StoreName)
                    .HasMaxLength(100).IsRequired();

            this.Property(p => p.StoreDescription)
                  .IsMaxLength().IsRequired();

        }
    }
}
