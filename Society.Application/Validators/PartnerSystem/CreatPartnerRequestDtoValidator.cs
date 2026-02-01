using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

using Society.Application.DTOs.PartnerSystem;

namespace Society.Application.Validators.PartnerSystem
{
    public class CreatPartnerRequestDtoValidator : AbstractValidator<CreatPartnerRequestDto>
    {
        public CreatPartnerRequestDtoValidator()
        {
            //Category
            RuleFor(x => x.Category).IsInEnum().WithMessage("Invalid requist category.");

            //Program
            RuleFor(x => x.Program).NotEmpty().WithMessage("Program is requierd.")
                .MinimumLength(10).WithMessage("Programm name too short.")
                .MaximumLength(100).WithMessage("Programm name too long.");

            //Subject
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is requierd.")
                .MinimumLength(10).WithMessage("Subject name too short.")
                .MaximumLength(100).WithMessage("Subject name too long.");

            //Description
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100).WithMessage("SuDescriptionbject name too long.");

            //RequierdPartnersCount
            RuleFor(x => x.RequierdPartnersCount).Must(count => count >= 1 && count <= 50)
                .WithMessage("Required partners count must be between 1 and 50.");

        }
    }
}