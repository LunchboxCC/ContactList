using ContactList.Server.Validators;
using ContactList.Shared;
using FluentValidation;
using FluentValidation.TestHelper;

namespace ContactList.Tests.ServerTests
{
    public class ValidationUnitTests
    {
        private readonly ContactValidator _contactValidator;

        public ValidationUnitTests()
        {
            _contactValidator = new ContactValidator();
        }

        [Theory]
        [InlineData("plain-old@address.com", true)]
        [InlineData("totally.valid@email.address.com", true)]
        [InlineData("s%t1LL@verymuch.ok", true)]
        [InlineData("v@l.id", true)]
        [InlineData("testing-email@withnotld", false)]
        [InlineData("@tooshortuserpart.com", false)]
        [InlineData("inv#lid@characters.de", false)]
        [InlineData("tld@tooshort.x", false)]
        [InlineData("numbers#intld.3com", false)]
        [InlineData("c@u", false)]
        public void EmailValidationAssessesCorrectly(string emailAddress, bool expectedResult)
        {
            var actualResult = _contactValidator.ValidateEmailAddress(emailAddress);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("720658742", true)]
        [InlineData("+44 720658742", true)]
        [InlineData("+420 720 658 742", true)]
        [InlineData("44+720658742", false)]
        [InlineData("72asd658742", false)]
        public void PhoneNumberValidationAssessesCorrectly(string phoneNumber, bool expectedResult)
        {
            var actualResult = _contactValidator.ValidatePhoneNumber(phoneNumber);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ValidationCatchesWhenEmailAddressIsInvalid()
        {
            var contact = new Contact()
            {
                FirstName = "Thomas",
                LastName = "Testing",
                EmailAddress = "Invalidgmail.com",
                PhoneNumber = "+420 720 257 365"
            };

            var result = _contactValidator.TestValidate(contact);
            result.ShouldHaveValidationErrorFor(contact => contact.EmailAddress);
        }

        [Fact]
        public void ValidationAllowsEmptyPhoneNumberWhenEmailAddressIsValid()
        {
            var contact = new Contact()
            {
                FirstName = "Thomas",
                LastName = "Testing",
                EmailAddress = "valid@gmail.com",
                PhoneNumber = ""
            };

            var result = _contactValidator.TestValidate(contact);
            result.ShouldNotHaveValidationErrorFor(contact => contact.PhoneNumber);
        }
    }
}
