namespace Contacts.Data.Common
{
    public static class DataConstants
    {
        // ApplicationUser constants:
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const string UsernameField = "Username";

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        // Contact constants:
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;

        public const int LastNameMinLength = 5;
        public const int LastNameMaxLength = 50;

        public const int ContactEmailMinLength = 10;
        public const int ContactEmailMaxLength = 60;

        public const int PhoneNumberMinLength = 10;
        public const int PhoneNumberMaxLength = 20;
        public const string PhoneRegex = @"^(0|\+359)( |-|)\d{3}\2\d{2}\2\d{2}\2\d{2}$";
        public const string PhoneInvalidMessage = "Invalid phone number!";

        public const int AddressMaxLength = 255;

        public const int WebsiteMaxLength = 255;
        public const string WebsiteRegex = @"^www\.[A-Za-z0-9\-]+\.(bg|com)$";
        public const string WebsiteInvalidMessage = "Invalid web address!";

        // Actions and controller names:
        public const string AllAction = "All";
        public const string ContactsContr = "Contacts";

        public const string IndexAction = "Index";
        public const string HomeContr = "Home";

        public const string InvalidLoginMessage = "Invalid Login!";
    }
}
