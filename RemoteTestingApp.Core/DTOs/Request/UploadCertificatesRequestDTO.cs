using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Core.DTOs.Request
{
    public class UploadCertificatesRequestDTO
    {
        
  
            //public string Url { get; set; }

            //[FileExtensions(Extensions ="pdf,docx")]
            public IFormFile WaecCertificate { get; set; }

            //[FileExtensions(Extensions = "pdf,docx")]
            public IFormFile UniversityCertificate { get; set; }

            //[FileExtensions(Extensions = "pdf,docx")]
            public IFormFile NyscCertificate { get; set; }

            //[FileExtensions(Extensions = "pdf,docx")]
            public IFormFile ProfessionalCertificate { get; set; }

            public string Description { get; set; }

            public DateTime DateAdded { get; set; }

            public string PublicId { get; set; }

            public Guid CandidateUniqueIdentifier { get; set; }


        public UploadCertificatesRequestDTO()
            {
                DateAdded = DateTime.Now;
            }
        
    }
}
