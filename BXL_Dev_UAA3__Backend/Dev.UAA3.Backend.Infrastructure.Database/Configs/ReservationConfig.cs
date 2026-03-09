using Dev.UAA3.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Dev.UAA3.Backend.Infrastructure.Database.Configs
{
    internal class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id)
                .HasName("PK_Reservations");

            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .HasMaxLength(200)
                .IsUnicode()
                .IsRequired();

            builder.Property(r => r.DateReserved)
                .HasColumnType("DATE")
                .IsRequired();

            builder.HasOne(r => r.Member)
                .WithMany()
                .HasForeignKey(r => r.MemberId)
                .IsRequired();

            builder.HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .IsRequired();
        }
    }
}
