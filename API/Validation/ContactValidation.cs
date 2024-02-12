using API.Model;
using FluentValidation;
namespace API.Validation
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        
        public ContactValidation() {
            RuleFor(contact => contact.Name).NotEmpty().MaximumLength(50);
            RuleFor(contact => contact.Surname).NotEmpty().MaximumLength(50);
            RuleFor(contact => contact.Password).NotEmpty().Must(password => IsStrongPassword(password)).WithMessage("Password must be strong");
            RuleFor(contact => contact.Email).NotEmpty().EmailAddress();
            RuleFor(contact => contact.Category).IsInEnum();
            RuleFor(contact => contact.Subcategory).NotEmpty().When(contact => contact.Category == Enum.CategoryContact.Private);
            RuleFor(contact => contact.PhoneNumber).NotEmpty().Matches(@"^[0-9]+$").Length(6, 12);
            RuleFor(contact => contact.BirthDate).NotEmpty().Must(birthDay => DateValidate(birthDay)).WithMessage("Birthday date is incorrect");

        }

        private bool IsStrongPassword(string password)
        {
            if(password.Length < 8)
            {
                return false;
            }
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                    continue;
                }
                if (char.IsLower(c))
                {
                    hasLowerCase = true;
                    continue;
                }
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                    continue;
                }
                if(char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    hasSpecialChar = true;
                    continue;
                }

            }
            if (!(hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar))
            {
                return false;
            }
            return true;
        }

        private bool DateValidate(DateTime dateTime)
        {
            return dateTime < DateTime.Now;
        }
    }
}
