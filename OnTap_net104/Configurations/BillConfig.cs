using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnTap_net104.Models;

namespace OnTap_net104.Configurations
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        void IEntityTypeConfiguration<Bill>.Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Status).HasColumnType("int");
            builder.Property(p => p.Username).HasColumnType("nvarchar(256)");
            builder.Property(p => p.CreateDate).HasColumnType("DATE");
            builder.HasOne(p => p.Account).WithMany(p => p.Bills).HasForeignKey(p => p.Username);
        }
    }
}
