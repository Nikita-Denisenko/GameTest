using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class EnemyConfiguration : IEntityTypeConfiguration<Enemy>
    {
        public void Configure(EntityTypeBuilder<Enemy> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Navigation(e => e.Properties)
               .UsePropertyAccessMode(PropertyAccessMode.Field);


            builder.OwnsOne(e => e.Loot, loot =>
            {
                loot.OwnsMany(l => l.Items, items =>
                {
                    items.WithOwner()
                        .HasForeignKey("EnemyLootId");

                    items.HasKey("EnemyLootId", "ItemId");

                    items.Property(i => i.ItemId)
                        .IsRequired()
                        .HasColumnName("ItemId");

                    items.Property(i => i.Chance)
                        .IsRequired()
                        .HasColumnName("Chance");
                });

                loot.OwnsOne(l => l.Gold, gold =>
                {
                    gold.Property(g => g.Min)
                        .IsRequired()
                        .HasColumnName("GoldMin");

                    gold.Property(g => g.Max)
                        .IsRequired()
                        .HasColumnName("GoldMax");
                });
                
                loot.OwnsOne(l => l.Experience, experience =>
                {
                    experience.Property(e => e.Min)
                        .IsRequired()
                        .HasColumnName("ExperienceMin");

                    experience.Property(e => e.Max)
                        .IsRequired()
                        .HasColumnName("ExperienceMax");
                });

                loot.Navigation(l => l.Items)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        }
    } 
}
