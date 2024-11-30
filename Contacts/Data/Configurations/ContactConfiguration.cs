using Contacts.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(new Contact()
            {
                Id = 1,
                FirstName = "Bruce",
                LastName = "Wayne",
                PhoneNumber = "+359881223344",
                Address = "Gotham City",
                Email = "imbatman@batman.com",
                Website = "www.batman.com"
            },
            new Contact()
            {
                Id = 2,
                FirstName = "Ivan",
                LastName = "Petrov",
                PhoneNumber = "+359882123456",
                Address = "Sofia City",
                Email = "ivan123@mail.bg",
                Website = "www.ivan-petrov199.com"
            },
            new Contact()
            {
                Id = 3,
                FirstName = "Ani",
                LastName = "Dimitrova",
                PhoneNumber = "+359888789456",
                Address = "Plovdiv City",
                Email = "ani-business@abv.bg",
                Website = "www.ani133ltd.bg"
            });
        }
    }
}
