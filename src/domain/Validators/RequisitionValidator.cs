using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Domain.Validators
{
    public class RequisitionValidator : AbstractValidator<Requisition>
    {
        public RequisitionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.JobId).NotEmpty();
        }
    }
}
