using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Domain
{
    public class Application
    {
        public Guid Id { get; set; }
        public Applicant Applicant { get; set; }
        public Requisition Requisition { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
