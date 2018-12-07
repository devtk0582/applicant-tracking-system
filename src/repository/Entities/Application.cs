using ATS.Persistence.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Persistence.Abstractions.Entities
{
    public class Application : IAggregateRoot
    {
        public Guid Id { get; set; }
        public Applicant Applicant { get; set; }
        public Requisition Requisition { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
