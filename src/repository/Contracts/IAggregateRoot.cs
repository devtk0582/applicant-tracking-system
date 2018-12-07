using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Persistence.Abstractions.Contracts
{
    public interface IAggregateRoot
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
    }
}
