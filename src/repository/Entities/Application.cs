using ATS.Persistence.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Persistence.Abstractions.Entities
{
    public class Application : IAggregateRoot
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid RequisitionId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
