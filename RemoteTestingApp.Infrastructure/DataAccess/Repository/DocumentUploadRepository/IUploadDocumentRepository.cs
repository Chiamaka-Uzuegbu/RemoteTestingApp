using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.DTOs.Response;
using System;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.DocumentUploadRepository
{
    public interface IUploadDocumentRepository
    {
        Task<bool> AddUploadDocumentAsync(UploadCertificatesRequestDTO docs);
        Task<UploadedDocumentResponseDTO> GetUploadedDocumentAsync(Guid UserUniqueIdentifier);
    }
}