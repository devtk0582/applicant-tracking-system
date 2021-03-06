﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Core.Domain
{
    public class Requisition 
    {
        public Guid Id { get; set; }
        public string JobId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
