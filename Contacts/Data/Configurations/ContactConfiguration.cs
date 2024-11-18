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
                FirstName = "Pesho",
                LastName = "Georgiev",
                PhoneNumber = "+359883123456",
                Address = "Sofia City",
                Email = "persho_g@gmail.com",
                Website = "peterandco-ltd.com"
            },
            new Contact()
            {
                Id = 3,
                FirstName = "Dimitrichko",
                LastName = "Petrov",
                PhoneNumber = "+359899123456",
                Address = "Plovdiv City",
                Email = "dimipetrov@mail.bg",
                Website = "dimi98.bg"
            });
        }
    }
}
