using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Application.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
    {
        public CreateApplicantCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 255);
            RuleFor(x => x.LastName).NotEmpty().Length(1, 255);
            RuleFor(x => x.Email).NotEmpty().Length(1, 255).EmailAddress();
        }
    }
}
