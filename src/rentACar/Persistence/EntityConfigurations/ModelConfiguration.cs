using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(t => t.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(t => t.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(t => t.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        builder.Property(t => t.ImageUrl).HasColumnName("ImageUrl").IsRequired();

        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: t => t.Name, name: "UK_Models_Name").IsUnique();
        builder.HasOne(t => t.Brand);
        builder.HasOne(t => t.Fuel);
        builder.HasOne(t => t.Transmission);
        builder.HasMany(t => t.Cars);

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}
