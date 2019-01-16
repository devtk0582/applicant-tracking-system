using ATS.Core.Domain;
using ATS.Persistence.Abstractions.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATS.Core.Application.Applicants.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, (bool Success, string Error)>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;

        public UpdateApplicantCommandHandler(IApplicantRepository applicantRepository,
            IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<(bool Success, string Error)> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = _mapper.Map<Applicant>(request);

            await _applicantRepository.UpsertApplicantAsync(applicant);

            return (true, string.Empty);
        }
    }
}
