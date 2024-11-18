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
        }
    }
}
