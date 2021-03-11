using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.DTOs.Request
{
    public class ReviewCompanyDocumentRequest
    {
        public Guid ReviewerUniqueIdentifier { get; set; }
        public Guid DocumentUnquieID { get; set; }
        public bool Accepted { get; set; }
        public DateTime SignDate { get; set; }

        public ReviewCompanyDocumentRequest()
        {
            SignDate = DateTime.Now;
        }
    }
}
