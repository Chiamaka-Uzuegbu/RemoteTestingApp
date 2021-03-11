using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.DTOs.Response;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository
{
    public interface IAuthenticationRepository
    {
        Task<bool> LoginAsync(SigninRequestDTO request);
        Task<bool> RegisterAsync(RegisterRequestDTO request);
        Task<RegisteredUserResponseDTO> GetRegisteredUser(string email);
        Task<bool> UserExistsAsync(string username);
    }
}