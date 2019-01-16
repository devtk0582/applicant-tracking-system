using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Application.Applicants.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandValidator : AbstractValidator<UpdateApplicantCommand>
    {
        public UpdateApplicantCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 255);
            RuleFor(x => x.LastName).NotEmpty().Length(1, 255);
            RuleFor(x => x.Email).NotEmpty().Length(1, 255).EmailAddress();
        }
    }
}
