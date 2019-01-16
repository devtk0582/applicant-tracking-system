using ATS.Core.Domain;
using ATS.Persistence.Abstractions.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATS.Core.Application.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, (bool Success, string Error)>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;

        public CreateApplicantCommandHandler(IApplicantRepository applicantRepository, 
            IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<(bool Success, string Error)> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = _mapper.Map<Applicant>(request);

            await _applicantRepository.AddApplicantAsync(applicant);

            return (true, string.Empty);
        }
    }
}
