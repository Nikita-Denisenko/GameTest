using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerWeaponPropertyConfiguration : IEntityTypeConfiguration<PlayerWeaponProperty>
    {
        public void Configure(EntityTypeBuilder<PlayerWeaponProperty> builder)
        {
            throw new NotImplementedException();
        }
    }
}
