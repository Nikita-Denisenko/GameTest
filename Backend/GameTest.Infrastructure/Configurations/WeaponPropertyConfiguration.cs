using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class WeaponPropertyConfiguration : IEntityTypeConfiguration<WeaponProperty>
    {
        public void Configure(EntityTypeBuilder<WeaponProperty> builder)
        {
            throw new NotImplementedException();
        }
    }
}
