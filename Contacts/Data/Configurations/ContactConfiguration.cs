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
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "+359891234567",
                Address = "NY City",
                Email = "john-doe@yahoo.com",
                Website = "www.johndoe.com"
            },
            new Contact()
            {
                Id = 3,
                FirstName = "Jenny",
                LastName = "Smith",
                PhoneNumber = "+359874567890",
                Address = "Miami-Beach",
                Email = "jenny110@gmail.com",
                Website = "www.jennys.com"
            });
        }
    }
}
