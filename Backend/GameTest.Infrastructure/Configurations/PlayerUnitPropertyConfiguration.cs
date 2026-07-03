using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerUnitPropertyConfiguration : IEntityTypeConfiguration<PlayerUnitProperty>
    {
        public void Configure(EntityTypeBuilder<PlayerUnitProperty> builder)
        {
            throw new NotImplementedException();
        }
    }
}
