using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnTap_net104.Models;

namespace OnTap_net104.Configurations
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        void IEntityTypeConfiguration<Cart>.Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p =>p.Username);
            builder.Property(p => p.Status).IsRequired().HasColumnType("int");
            builder.Property(p => p.Description).HasColumnType("nvarchar(256)");
            builder.HasOne(p => p.Account).WithOne(p => p.Cart).HasForeignKey<Account>(p => p.Username);
        }
    }
}
