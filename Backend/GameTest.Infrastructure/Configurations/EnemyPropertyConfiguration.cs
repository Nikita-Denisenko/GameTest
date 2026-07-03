using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class EnemyPropertyConfiguration : IEntityTypeConfiguration<EnemyProperty>
    {
        public void Configure(EntityTypeBuilder<EnemyProperty> builder)
        {
            throw new NotImplementedException();
        }
    }
}
