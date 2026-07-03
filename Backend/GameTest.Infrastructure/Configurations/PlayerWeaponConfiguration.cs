using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerWeaponConfiguration : IEntityTypeConfiguration<PlayerWeapon>
    {
        public void Configure(EntityTypeBuilder<PlayerWeapon> builder)
        {
            throw new NotImplementedException();
        }
    }
}
