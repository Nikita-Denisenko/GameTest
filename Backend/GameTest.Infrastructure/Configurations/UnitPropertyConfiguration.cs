using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class UnitPropertyConfiguration : IEntityTypeConfiguration<UnitProperty>
    {
        public void Configure(EntityTypeBuilder<UnitProperty> builder)
        {
            throw new NotImplementedException();
        }
    }
}
