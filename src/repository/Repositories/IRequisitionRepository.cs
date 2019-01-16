using ATS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATS.Persistence.Abstractions.Repositories
{
    public interface IRequisitionRepository
    {
        IEnumerable<Requisition> GetRequisitions();
        Requisition GetRequisitionById(Guid id);
        void AddRequisition(Requisition requisition);
        void UpdateRequisition(Requisition requisition);
        void DeleteRequisition(Guid id);
        void UpsertRequisition(Requisition requisition);

        Task AddRequisitionAsync(Requisition requisition);
        Task UpdateRequisitionAsync(Requisition requisition);
        Task DeleteRequisitionAsync(Guid id);
        Task UpsertRequisitionAsync(Requisition requisition);
    }
}
