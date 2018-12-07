using ATS.Persistence.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Persistence.Abstractions.Entities
{
    public class Applicant : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
