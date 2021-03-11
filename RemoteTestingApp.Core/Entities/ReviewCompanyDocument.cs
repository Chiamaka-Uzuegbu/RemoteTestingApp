using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.Entities
{
    public class ReviewCompanyDocument
    {
        public int id { get; set; }
        public Guid DocumentUnquieID { get; set; }
        public DateTime SignDate { get; set; }
        public Guid ReviewerUniqueIdentifier { get; set; }
        public bool Accepted { get; set; }
    }
}
