﻿using Contacts.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Contacts.Data.Common.DataConstants;

namespace Contacts.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(au => au.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();

            builder.Property(au => au.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();
        }
    }
}
