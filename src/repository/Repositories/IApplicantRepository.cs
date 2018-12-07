using ATS.Persistence.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Persistence.Abstractions.Repositories
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetApplicants();
        Applicant GetApplicantById(Guid id);
        void AddApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void DeleteApplicant(Guid id);
    }
}
