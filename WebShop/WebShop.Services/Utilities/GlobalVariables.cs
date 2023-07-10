using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Services.Utilities
{
    public class GlobalVariables
    {
        public class ErrorMessages
        {
            public const string NotFound = "Error not found!";

            public const string InvalidInput = "Error invalid input!";

            public class Passwords
            {
                public const string NotMatchingPassword = "The password confirmation does not match.";
            }

        }

        public class AttributeValidations
        {
            public class AccountUser
            {
                public const int FirstNameMinLength = 2;
                public const int LastNameMinLength = 2;
                public const int UserNameMinLength = 2;

                public const int FirstNameMaxLength = 40;
                public const int LastNameMaxLength = 50;
                public const int UserNameMaxLength = 50;

            }
        }
    }
}
