using FluentValidation;
using Society.Application.DTOs.TeamSystem.TeamFormation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Application.Validators.TeamSystem.TeamFormation
{
    public class CreateTeamFormationDtoValidator : AbstractValidator<CreateTeamFormationDto>
    {
        public CreateTeamFormationDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.ProgramId)
                .NotEmpty()
                .WithMessage("Program must be selected.");

            RuleFor(x => x.SubjectId)
                .NotEmpty()
                .WithMessage("Subject must be selected.");

            RuleFor(x => x.MaxMembers)
                .InclusiveBetween(1, 20)
                .WithMessage("MaxMembers must be between 1 and 20.");
        }
    }

}
