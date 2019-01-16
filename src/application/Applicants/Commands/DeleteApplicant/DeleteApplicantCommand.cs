using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Application.Applicants.Commands.DeleteApplicant
{
    public class DeleteApplicantCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
