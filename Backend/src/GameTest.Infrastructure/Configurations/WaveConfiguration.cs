using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class WaveConfiguration : IEntityTypeConfiguration<Wave>
    {
        public void Configure(EntityTypeBuilder<Wave> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();


            builder.Navigation(w => w.Enemies)
                .UsePropertyAccessMode(PropertyAccessMode.Field);


            builder.OwnsMany(w => w.Enemies, waves =>
            {
                waves.WithOwner()
                    .HasForeignKey("WaveId");


                waves.HasKey("WaveId", "EnemyId");


                waves.Property(w => w.EnemyId)
                    .IsRequired()
                    .HasColumnName("EnemyId")
                    .ValueGeneratedNever();


                waves.HasOne<Enemy>()
                    .WithMany()
                    .HasForeignKey(w => w.EnemyId)
                    .OnDelete(DeleteBehavior.Cascade);


                waves.Property(w => w.SpawnInterval)
                    .IsRequired()
                    .HasColumnName("SpawnInterval");


                waves.OwnsOne(w => w.QuantityRange, quantityRange =>
                {
                    quantityRange.Property(q => q.Min)
                        .IsRequired()
                        .HasColumnName("QuantityMin");

                    quantityRange.Property(q => q.Max)
                        .IsRequired()
                        .HasColumnName("QuantityMax");
                });
            });
        }
    }
}
