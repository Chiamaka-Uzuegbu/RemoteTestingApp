using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.Entities
{
    public class UploadedDocument
    {
        public int id { get; set; }

        //public string Url { get; set; }

    
        public byte[] WaecCertificate { get; set; }

       
        public byte[] UniversityCertificate { get; set; }

       
        public byte[] NyscCertificate { get; set; }

        
        public byte[] ProfessionalCertificate { get; set; }


        public DateTime DateAdded { get; set; }

        public string Description { get; set; }

        public Guid CandidateUniqueIdentifier { get; set; }

        public string PublicId { get; set; }
    }
}
