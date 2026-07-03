using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class UnitStatConfiguration : IEntityTypeConfiguration<UnitStat>
    {
        public void Configure(EntityTypeBuilder<UnitStat> builder)
        {
            throw new NotImplementedException();
        }
    }
}
