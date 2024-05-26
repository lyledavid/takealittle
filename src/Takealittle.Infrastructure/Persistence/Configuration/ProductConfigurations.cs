using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Takealittle.Domain.Entities;

namespace Takealittle.Infrastructure.Persistence.Configuration;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // builder.HasKey(x => x.Id);
        // builder.Property(x => x.Name)
        //     .HasMaxLength(200)
        //     .IsRequired();
        // builder.Property(x => x.Barcode)
        //     .HasMaxLength(12)
        //     .IsRequired();
        // builder.Property(x => x.Description)
        //     .HasMaxLength(1000);
        // builder.Property(x => x.Price)
        //     .HasColumnType("decimal(10,2)");
        // builder.OwnsMany<ProductImage>(x => x.ProductImages, y =>
        // {
        //     y.ToTable("ProductImages");
        //     y.WithOwner().HasForeignKey("Id");
        //     y.Property(p => p.Id)
        //         .HasColumnName("ProductImageId")
        //         .ValueGeneratedNever();
        // });
    }
}