using FluentValidation;
using Society.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Validators
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd")
            .EmailAddress().WithMessage("Email is invalid");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd");
        }
    }
}
