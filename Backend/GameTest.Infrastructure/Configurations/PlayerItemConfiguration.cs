using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerItemConfiguration : IEntityTypeConfiguration<PlayerItem>
    {
        public void Configure(EntityTypeBuilder<PlayerItem> builder)
        {
            throw new NotImplementedException();
        }
    }
}
