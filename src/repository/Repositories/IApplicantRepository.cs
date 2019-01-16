using ATS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATS.Persistence.Abstractions.Repositories
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetApplicants();
        Applicant GetApplicantById(Guid id);
        void AddApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void DeleteApplicant(Guid id);
        void UpsertApplicant(Applicant applicant);

        Task AddApplicantAsync(Applicant applicant);
        Task UpdateApplicantAsync(Applicant applicant);
        Task DeleteApplicantAsync(Guid id);
        Task UpsertApplicantAsync(Applicant applicant);
    }
}
