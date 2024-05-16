using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnTap_net104.Models;

namespace OnTap_net104.Configurations
{
    public class BillDetailsConfig : IEntityTypeConfiguration<BillDetail>
    {
        void IEntityTypeConfiguration<BillDetail>.Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).HasColumnType("nvarchar(256)");
            builder.Property(p => p.ProductPrice).HasColumnType("decimal");
            builder.Property(p => p.Quantity).HasColumnType("int");
            builder.Property(x => x.Status).IsRequired().HasColumnType("int");
            builder.HasOne(p=>p.Bill).WithMany(p => p.BillDetails).HasForeignKey(p => p.BillId);
            builder.HasOne (p => p.Product).WithMany(p => p.BillDetails).HasForeignKey(p => p.ProductId);
            
        }
    }
}
