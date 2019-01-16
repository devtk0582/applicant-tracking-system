using ATS.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Application.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommand : IRequest<(bool Success, string Error)>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
