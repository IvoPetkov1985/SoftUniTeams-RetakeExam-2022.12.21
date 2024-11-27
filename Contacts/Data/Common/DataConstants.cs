namespace Contacts.Data.Common
{
    public static class DataConstants
    {
        // ApplicationUser constants:
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const int UserEmailMinLength = 10;
        public const int UserEmailMaxLength = 60;

        public const string UsernameDisplay = "Username";
        public const string LoginInvalidMessage = "Invalid Login, please try again!";

        // Contact constants:
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;
        public const string FirstNameRequiredMsg = "First name is required.";
        public const string FirstNameLengthMsg = "First name should be between {2} and {1} charcters long.";

        public const int LastNameMinLength = 5;
        public const int LastNameMaxLength = 50;
        public const string LastNameRequiredMsg = "Last name is required.";
        public const string LastNameLengthMsg = "Last name should be between {2} and {1} charcters long.";

        public const int ContactEmailMinLength = 10;
        public const int ContactEmailMaxLength = 60;

        public const int PhoneNumberMinLength = 10;
        public const int PhoneNumberMaxLength = 18;
        public const string PhoneRegex = @"^(\+359|0)(-| |)\d{3}\2\d{2}\2\d{2}\2\d{2}$";
        public const string PhoneInvalidMessage = "Invalid phone number.";
        public const string PhoneRequiredMsg = "Phone number is required.";
        public const string PhoneLengthMsg = "Phone number should be between {2} and {1} symbols long.";

        public const int AddressMaxLength = 255;
        public const int WebsiteMaxLength = 255;

        public const string WebsiteRegex = @"^www\.[A-Za-z0-9\-]+\.(bg|com)$";
        public const string WebsiteInvalidMessage = "Invalid website.";

        // Actions and controllers:
        public const string AllActionName = "All";
        public const string IndexActionName = "Index";
        public const string ContactsContrName = "Contacts";
        public const string HomeContrName = "Home";
    }
}
