using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnTap_net104.Models;

namespace OnTap_net104.Configurations
{
    public class CartDetailsConfig : IEntityTypeConfiguration<CartDetails>
    {
        void IEntityTypeConfiguration<CartDetails>.Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Quantity).HasColumnType("int");
            builder.Property(p => p.ProductPrice).HasColumnType("decimal");
            builder.Property(p => p.Status).IsRequired().HasColumnType("int");
            builder.HasOne(p=>p.Cart).WithMany(p=>p.CartDetails).HasForeignKey(p =>p.Username);
            builder.HasOne(p => p.Product).WithMany(p => p.CartDetails).HasForeignKey(p => p.ProductId);
        }
    }
}
