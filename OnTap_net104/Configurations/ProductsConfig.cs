using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnTap_net104.Models;

namespace OnTap_net104.Configurations
{
    public class ProductsConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey( x => x.ID );
            builder.Property(p => p.Status).HasColumnType("int");
            builder.Property(p => p.Name).HasColumnType("nvarchar(256)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(256)");
            builder.Property(p => p.Quantity).HasColumnType("int");
            builder.Property(p => p.Price).HasColumnType("decimal");
        }
    }
}
