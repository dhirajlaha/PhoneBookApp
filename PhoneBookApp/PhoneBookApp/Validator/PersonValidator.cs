using FluentValidation;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Validator
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(c => c.Name).Must(n => ValidateStringEmpty(n)).WithMessage("Contact name should not be empty.");
            RuleFor(c => c.PhoneNumber).NotNull().Length(10);
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid Email.");
            RuleFor(c => c.Address).Must(a => ValidateStringEmpty(a)).WithMessage("Contact Adress should not be empty.");
        }

        private bool ValidateStringEmpty(string n)
        {
            if(!string.IsNullOrEmpty(n)) 
                return true;
            return false;
        }
    }
}
