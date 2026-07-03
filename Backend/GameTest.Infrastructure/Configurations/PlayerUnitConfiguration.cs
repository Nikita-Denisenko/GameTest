using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerUnitConfiguration : IEntityTypeConfiguration<PlayerUnit>
    {
        public void Configure(EntityTypeBuilder<PlayerUnit> builder)
        {
            throw new NotImplementedException();
        }
    }
}
