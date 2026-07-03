using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class EnemyStatConfiguration : IEntityTypeConfiguration<EnemyStat>
    {
        public void Configure(EntityTypeBuilder<EnemyStat> builder)
        {
            throw new NotImplementedException();
        }
    }
}
