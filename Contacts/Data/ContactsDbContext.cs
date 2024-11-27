using Contacts.Data.Configurations;
using Contacts.Data.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext<ApplicationUser>
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ApplicationUserContactConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
