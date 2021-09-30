using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(1).When(x => string.IsNullOrWhiteSpace(x.LastName));

            RuleFor(x => x.LastName).NotNull().WithMessage("Last name is requred!");

            RuleFor(x => x.PhoneNumber).Must(x => CheckPhoneNumber(x));

            RuleFor(x => x.AddressId).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1000);
        }

        private bool CheckPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Contains("0");
        }
    }
}
