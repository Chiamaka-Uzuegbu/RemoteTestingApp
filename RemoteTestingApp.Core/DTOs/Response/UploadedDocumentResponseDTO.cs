using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.DTOs.Response
{
    public class UploadedDocumentResponseDTO
    {

        public string WaecCertificate { get; set; }


        public string UniversityCertificate { get; set; }


        public string NyscCertificate { get; set; }


        public string ProfessionalCertificate { get; set; }


        public DateTime DateAdded { get; set; }

        public string Description { get; set; }

        public Guid CandidateUniqueIdentifier { get; set; }

    }
}
