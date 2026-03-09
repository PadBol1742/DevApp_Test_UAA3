using Dev.UAA3.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.UAA3.Backend.Infrastructure.Database.Configs
{
    internal class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(r => r.Id)
                .HasName("PK_Rooms");

            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(r => r.Name)
                .IsUnique()
                .HasDatabaseName("IX_Rooms__Name");
        }
    }
}
