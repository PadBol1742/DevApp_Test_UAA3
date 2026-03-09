using Dev.UAA3.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.UAA3.Backend.Infrastructure.Database.Configs
{
    internal class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.Id)
                .HasName("PK_Members");

            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Email)
                .HasMaxLength(320)
                .IsUnicode()
                .IsRequired();

            builder.Property(m => m.Password)
                .HasColumnName("Password_hashed")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(m => m.Email)
                .IsUnique()
                .HasDatabaseName("IX_Members__Email");
        }
    }
}
