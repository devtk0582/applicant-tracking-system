using ATS.Persistence.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Persistence.Abstractions.Repositories
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetApplications();
        Application GetApplicationById(Guid id);
        void AddApplication(Application application);
        void UpdateApplication(Application application);
        void DeleteApplication(Guid id);
        void UpsertApplication(Application application);

        Task AddApplicationAsync(Application application);
        Task UpdateApplicationAsync(Application application);
        Task DeleteApplicationAsync(Guid id);
        Task UpsertApplicationAsync(Application application);
    }
}
