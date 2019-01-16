using ATS.Persistence.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATS.Core.Application.Applicants.Commands.DeleteApplicant
{
    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand>
    {
        private readonly IApplicantRepository _applicantRepository;

        public DeleteApplicantCommandHandler(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<Unit> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            await _applicantRepository.DeleteApplicantAsync(request.Id);

            return Unit.Value;
        }
    }
}
