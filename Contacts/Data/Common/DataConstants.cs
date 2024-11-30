namespace Contacts.Data.Common
{
    public static class DataConstants
    {
        // ApplicationUser constants:
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        // Contact constants:
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;

        public const int LastNameMinLength = 5;
        public const int LastNameMaxLength = 50;

        public const int PhoneNumberMinLength = 10;
        public const int PhoneNumberMaxLength = 18;
        public const string PhoneRegex = @"^(0|\+359)(-| |)\d{3}\2\d{2}\2\d{2}\2\d{2}$";
        public const string PhoneInvalid = "Invalid phone number format.";

        public const int AddressMaxLength = 255;
        public const int WebsiteMaxLength = 255;

        public const string WebsiteRegex = @"^www\.[A-Za-z0-9-]+\.(bg|com)$";
        public const string WebsiteInvalid = "Invalid website format.";

        // Error messages:
        public const string RequiredFieldErrorMsg = "This field is required.";
        public const string LengthErrorMsg = "This field should be between {2} and {1} characters long.";
        public const string LoginFailedMsg = "Invalid Login! Please try again.";
        public const string PasswordNotMatchingMsg = "'Confirm Password' does not match with 'Password'.";

        // Actions and controllers:
        public const string AllAction = "All";
        public const string IndexAction = "Index";
        public const string ContactsContr = "Contacts";
        public const string HomeContr = "Home";
    }
}
