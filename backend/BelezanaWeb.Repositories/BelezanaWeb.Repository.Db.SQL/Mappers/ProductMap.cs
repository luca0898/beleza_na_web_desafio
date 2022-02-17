using BelezanaWeb.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezanaWeb.Db.SQL.Mappers
{
    public class ProductMap : IEntityTypeConfiguration<Product.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Product.Entities.Product> builder)
        {
            builder
                .HasKey(prop => prop.Id);

            builder
                .Property(prop => prop.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(prop => prop.Sku)
                .IsRequired();

            builder
                .Property(prop => prop.Name)
                .IsRequired();

            builder
                .HasOne(a => a.Inventory)
                .WithOne(b => b.Product)
                .HasForeignKey<Inventory>(b => b.Id);

            builder
                .Property(prop => prop.IsMarketable)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
