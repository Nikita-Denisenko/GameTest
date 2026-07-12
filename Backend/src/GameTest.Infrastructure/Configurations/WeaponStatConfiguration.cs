using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class WeaponStatConfiguration : IEntityTypeConfiguration<WeaponStat>
    {
        public void Configure(EntityTypeBuilder<WeaponStat> builder)
        {
            builder.HasKey(ws => ws.Id);

            builder.Property(ws => ws.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
