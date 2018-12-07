using System;
using System.Collections.Generic;
using System.Linq;

namespace ATS.Core.Domain
{
    public class Applicant
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
