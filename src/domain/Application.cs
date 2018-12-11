using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Domain
{
    public class Application
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid RequisitionId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
