using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.PersonDetailRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteTestingApp.Controllers
{
    
    [Route("api/PersonalDetails/")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IFileLogger _logger;
        private readonly IPersonalDetailsRepository _repo;
        private readonly ITokenProvider _provider;

        public PersonalDetailsController(IFileLogger logger, IPersonalDetailsRepository repo, 
            ITokenProvider provider)
        {
            _logger = logger;
            _repo = repo;
            _provider = provider;

        }

        [HttpGet("GetPersonalDetailAsync/{UseruniqueId}")]
        public async Task<IActionResult> GetPersonalDetail(Guid UseruniqueId)
        {
            var response = await _repo.GetPersonalDetailAsync(UseruniqueId);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Details Not Found");
            
        }

        [Authorize]
        [HttpPost("CreatePersonalDetails")]
        public async Task<IActionResult> CreatePersonalDetails(PersonalDetailsRequestDTO request)
        {

            var result =await _repo.CreatePersonalDetailAsync(request);

            if (result.Item1)
            {
                return CreatedAtAction("GetPersonalDetail",new { UseruniqueId =result.Item2 },"User Details Created Successfully");
            }

            return BadRequest("Unable to Create User");
        }

    }
}
