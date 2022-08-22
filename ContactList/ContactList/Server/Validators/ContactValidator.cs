using FluentValidation;
using System.Text.RegularExpressions;

namespace ContactList.Server.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.EmailAddress).NotEmpty().When(c => c.PhoneNumber == string.Empty);
            RuleFor(c => c.EmailAddress).Must(e => ValidateEmailAddress(e)).When(c => c.EmailAddress != string.Empty);
            RuleFor(c => c.PhoneNumber).NotEmpty().When(c => c.EmailAddress == string.Empty);
            RuleFor(c => c.PhoneNumber).Must(pn => ValidatePhoneNumber(pn)).When(c => c.PhoneNumber != string.Empty);
        }

        public bool ValidateEmailAddress(string emailAddress)
        {
            int minTotalLength = 6;
            int maxTotalLength = 254;

            if (emailAddress.Length > maxTotalLength || emailAddress.Length < minTotalLength)
                return false;

            var emailPattern = @"^[\w+\.%-]{1,64}@(?:[\w+%-]+\.)+[aA-zZ]{2,}$";

            if (!Regex.IsMatch(emailAddress, emailPattern))
                return false;

            return true;
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            string phoneNumberNoSpaces = phoneNumber.Replace(" ", "");

            if (phoneNumberNoSpaces.Count() == 0)
                return false;

            if (phoneNumberNoSpaces.Contains('+') && (!phoneNumberNoSpaces.StartsWith('+') || phoneNumberNoSpaces.Count(c => c == '+') > 1))
                return false;

            if (phoneNumberNoSpaces.Count(c => char.IsDigit(c)) < phoneNumberNoSpaces.Count() - 1)
                return false;

            return true;
        }
    }
}
