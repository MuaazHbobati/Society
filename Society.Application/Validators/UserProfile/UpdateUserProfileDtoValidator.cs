using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Society.Application.DTOs.UserProfile;

namespace Society.Application.Validators.UserProfile
{
    public class UpdateUserProfileDtoValidator : AbstractValidator<UpdateUserProfileDto>
    {
        public UpdateUserProfileDtoValidator()
        {
            //Bio
            RuleFor(x => x.Bio).MaximumLength(300).WithMessage("Bio cannot exceed 300 characters.");

            //Major
            RuleFor(x => x.Major).NotEmpty().WithMessage("Major is requierd");

            //Faculty
            RuleFor(x => x.Faculty).NotEmpty().WithMessage("Faculty is requierd");

            //University
            RuleFor(x => x.University).NotEmpty().WithMessage("University is requierd");

            //City
            RuleFor(x => x.City).NotEmpty().WithMessage("City is requierd");
        }
    }
}
