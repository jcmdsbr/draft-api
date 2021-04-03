using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.SQL.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), "dbo");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.BarCode)
                .HasColumnType("varchar(12)")
                .IsRequired()
                .HasMaxLength(12);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

        }
    }
}