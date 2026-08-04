using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerLevelConfiguration : IEntityTypeConfiguration<PlayerLevel>
    {
        public void Configure(EntityTypeBuilder<PlayerLevel> builder)
        {
            builder.HasKey(pl => pl.Id);

            builder.Property(pl => pl.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
