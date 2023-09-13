using App.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.DataLayer.Configurations
{
    public class UserUsedPasswordConfiguration : IEntityTypeConfiguration<UserUsedPassword>
    {
        public void Configure(EntityTypeBuilder<UserUsedPassword> builder)
        {
            builder.ToTable("AppUserUsedPasswords");

            builder.Property(applicationUserUsedPassword => applicationUserUsedPassword.HashedPassword)
                   .HasMaxLength(450)
                   .IsRequired();

            builder.HasOne(applicationUserUsedPassword => applicationUserUsedPassword.User)
                   .WithMany(applicationUser => applicationUser.UserUsedPasswords);
        }
    }
}