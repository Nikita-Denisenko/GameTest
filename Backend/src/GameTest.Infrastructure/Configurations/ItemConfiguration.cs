using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(i => i.Effect, e =>
            {
                e.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("EffectName");

                e.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("EffectDescription");

                e.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("EffectType");

                e.OwnsMany(eff => eff.Levels, levels =>
                {
                    levels.WithOwner()
                        .HasForeignKey("ItemEffectId");

                    levels.HasKey("ItemEffectId", "Level");

                    levels.Property(l => l.Level)
                        .IsRequired()
                        .ValueGeneratedNever()
                        .HasColumnName("Level");

                    levels.Property(l => l.Value).IsRequired()
                        .IsRequired()
                        .HasColumnName("Bonus");

                    levels.Property(l => l.Price)
                        .IsRequired()
                        .HasColumnName("Price");
                });
            });

            builder.OwnsMany(up => up.TemporaryLevels, temporaryLevels =>
            {
                temporaryLevels.WithOwner().HasForeignKey("ItemId");

                temporaryLevels.HasKey("ItemId", "Level");

                temporaryLevels.Property(l => l.Level)
                    .IsRequired()
                    .ValueGeneratedNever()
                    .HasColumnName("Level");

                temporaryLevels.Property(l => l.Bonus)
                    .IsRequired()
                    .HasColumnName("Bonus");

                temporaryLevels.Property(l => l.Price)
                    .IsRequired()
                    .HasColumnName("Price");
            });

            builder.Navigation(up => up.TemporaryLevels)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
