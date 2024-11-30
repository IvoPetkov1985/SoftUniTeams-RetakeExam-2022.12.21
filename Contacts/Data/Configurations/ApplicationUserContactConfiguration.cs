using Contacts.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Data.Configurations
{
    public class ApplicationUserContactConfiguration : IEntityTypeConfiguration<ApplicationUserContact>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserContact> builder)
        {
            builder.HasKey(uc => new
            {
                uc.ApplicationUserId,
                uc.ContactId
            });

            builder.HasOne(uc => uc.Contact)
                .WithMany(c => c.ApplicationUsersContacts)
                .HasForeignKey(uc => uc.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(uc => uc.ApplicationUser)
                .WithMany(u => u.ApplicationUsersContacts)
                .HasForeignKey(uc => uc.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
