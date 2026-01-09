using EscolaManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaManager.Infrastructure.Data.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {

            builder.ToTable("Cargos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeCargo)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(c => c.Escola)
                .WithMany()
                .HasForeignKey(c => c.EscolaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Permissoes)
                .WithMany()
                .UsingEntity(j => j.ToTable("CargoPermissoes"));

            builder.Navigation(c => c.Permissoes)
                .HasField("_permissoes")
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}