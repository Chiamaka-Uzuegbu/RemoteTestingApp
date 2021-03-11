using RemoteTestingApp.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.PersonDetailRepository
{
    public interface IPersonalDetailsRepository
    {
        Task<(bool,Guid)> CreatePersonalDetailAsync(PersonalDetailsRequestDTO request);
        Task<List<PersonalDetailsRequestDTO>> GetAllPersonalDetailAsync();
        Task<PersonalDetailsRequestDTO> GetPersonalDetailAsync(Guid UseruniqueId);
    }
}