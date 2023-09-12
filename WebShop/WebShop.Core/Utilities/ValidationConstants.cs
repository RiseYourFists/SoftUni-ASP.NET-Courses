namespace WebShop.Core.Utilities
{
    namespace Validation
    {
        public class BrandConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
        }

        public class CategoryConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
        }

        public class PromotionConstants
        {
            public const int NameMaxLength = 50;
        }

        public class ProductConstants
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 2;
            public const int DescriptionMaxLength = 700;
            public const int DescriptionMinLength = 50;
            public const string PriceMaxValue = "79228162514264337593543950335"; 
            public const string PriceMinValue = "0";
            public const int QuantityMaxRange = int.MaxValue;
            public const int QuantityMinRange = 0;
        }

        public class AccountUserConstants
        {
            public const int FirstNameMinLength = 2;
            public const int LastNameMinLength = 2;
            public const int UserNameMinLength = 2;

            public const int FirstNameMaxLength = 40;
            public const int LastNameMaxLength = 50;
            public const int UserNameMaxLength = 50;

        }

        public class SharedConstants
        {
            public const int ImgUrlMaxLength = 2083;
        }
    }

    namespace GlobalVariables
    {
        public class ErrorMessages
        {
            public const string NotFound = "Error not found!";

            public const string InvalidInput = "Error invalid input!";

            public const string ValueOutOfRange = "Error: Value out of range!";

            public const string CategoryNotFound = "Error: Category not found!";

            public const string BrandNotFound = "Error: Brand not found!";

            public class Passwords
            {
                public const string NotMatchingPassword = "The password confirmation does not match.";
            }
        }
    }
}
