using FluentValidation;
using Society.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Validators
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            //FirstName
            RuleFor(x => x.FirstName).NotEmpty()
            .WithMessage("First name is requierd")
            .MinimumLength(2).WithMessage("First name must be at least 2 characters");
          
            //LastName
            RuleFor(x => x.LastName).NotEmpty()
            .WithMessage("Last name is requierd")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters");

            //Email
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd")
            .EmailAddress().WithMessage("Email is invalid");

            //SVUMail
            RuleFor(x => x.SVUMail).NotEmpty()
           .WithMessage("SVU Mail is required")
           .EmailAddress().WithMessage("SVU Mail is invalid")
           .Must(email => email.EndsWith("@svuonline.org", StringComparison.OrdinalIgnoreCase))
           .WithMessage("SVU Mail must be right");

            //Username
            RuleFor(x => x.Username).NotEmpty()
            .WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters")
            .MaximumLength(20).WithMessage("Username must not exceed 20 characters")
            .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscore");

            //Password
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters");

            //Gender
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gendor is requierd")
            .Must(x => x == "Male" || x == "Female").WithMessage("Gender must be 'Male' or 'Female'");

            //BirthDate
            RuleFor(x => x.BirthDate).LessThan(DateTime.Today).WithMessage("BirthDate must be in the past");
        }
    }
}
