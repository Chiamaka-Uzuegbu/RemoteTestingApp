using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Entities;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.ReviewRepository
{
    public interface IReviewDocumentRepository
    {
        Task<bool> CreateReviewDocumentAsync(ReviewCompanyDocumentRequest request);
        Task<CompanyDocument> GetCompanyDocumentAsync(int id);
    }
}