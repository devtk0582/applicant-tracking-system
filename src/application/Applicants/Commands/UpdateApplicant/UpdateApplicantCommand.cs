using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Application.Applicants.Commands.UpdateApplicant
{
    public class UpdateApplicantCommand : IRequest<(bool Success, string Error)>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
