using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnTap_net104.Models;

namespace OnTap_net104.Configurations
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Username);
            builder.Property(p => p.Password).HasColumnType("varchar(256)");
            builder.Property(p => p.Address).HasColumnType("nvarchar(256)");
        }
    }
}
