using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Domain.Validators
{
    public class ApplicationValidator : AbstractValidator<Application>
    {
        public ApplicationValidator()
        {
            RuleFor(x => x.ApplicantId).NotEmpty();
            RuleFor(x => x.RequisitionId).NotEmpty();
        }
    }
}
