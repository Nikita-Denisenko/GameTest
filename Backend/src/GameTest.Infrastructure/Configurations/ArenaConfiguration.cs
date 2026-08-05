using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class ArenaConfiguration : IEntityTypeConfiguration<Arena>
    {
        public void Configure(EntityTypeBuilder<Arena> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
