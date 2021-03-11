﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.Entities
{
    public class CompanyDocument
    {
        public string CompanyPolicy { get; set; }

        public string TermsAndConditions { get; set; }

        public Guid DocumentUnquieID { get; set; }


        public int Id { get; set; }
    }
}
