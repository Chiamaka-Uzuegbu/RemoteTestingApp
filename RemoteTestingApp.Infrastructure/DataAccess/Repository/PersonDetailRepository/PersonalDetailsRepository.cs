using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Entities;
using RemoteTestingApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.PersonDetailRepository
{
    public class PersonalDetailsRepository : IPersonalDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileLogger _logger;
        private readonly IMapper _mapper;

        public PersonalDetailsRepository(ApplicationDbContext context,
            IFileLogger logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(bool,Guid)> CreatePersonalDetailAsync(PersonalDetailsRequestDTO request)
        {
           

            try
            {

                var newUpdate = _mapper.Map<PersonalDetails>(request);
                newUpdate.UserDetailsUniqueIdentifier = Guid.NewGuid();


                await _context.UserPersonalDetails.AddAsync(newUpdate);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {

                    return (true, newUpdate.UserDetailsUniqueIdentifier);
                }
                return (false,default);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + "Inner Exception" + ex.InnerException.Message, "  CreatePersonalDetailAsync");
                
            }
            return (default,default);
        }

        public async Task<PersonalDetailsRequestDTO> GetPersonalDetailAsync(Guid UseruniqueId)
        {
            try
            {
                var result = await _context.UserPersonalDetails.SingleOrDefaultAsync(x => x.UserDetailsUniqueIdentifier == UseruniqueId);
                var response = _mapper.Map<PersonalDetailsRequestDTO>(result);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + "Inner Exception" + ex.InnerException.Message, "  GetPersonalDetailAsync");
                return default;
            }

        }

        public async Task<List<PersonalDetailsRequestDTO>> GetAllPersonalDetailAsync()
        {
            try
            {
                var articles = await _context.UserPersonalDetails.ToListAsync();
                var response = _mapper.Map<List<PersonalDetailsRequestDTO>>(articles);

                return response;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message, "GetAllPersonalDetailAsync");
                return default;
            }


        }

    }
}
