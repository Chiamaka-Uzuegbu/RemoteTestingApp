using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.ReviewRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteTestingApp.Controllers
{
    [Route("api/ReviewDocument")]
    [ApiController]
    public class ReviewDocumentController : ControllerBase
    {
        private readonly IFileLogger _logger;
        private readonly IReviewDocumentRepository _repo;
        private readonly ITokenProvider _provider;

        public ReviewDocumentController(IFileLogger logger, IReviewDocumentRepository repo, ITokenProvider provider)
        {
            _logger = logger;
            _repo = repo;
            _provider = provider;
        }

        [Authorize]
        [HttpGet("CompanyDocument")]
        public async Task<IActionResult> GetCompanyDocument()
        {
            var response = await _repo.GetCompanyDocumentAsync(1);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound("Unable to find document");
        }

        [Authorize]
        [HttpPost("Review")]
        public async Task<IActionResult> CreateReview(ReviewCompanyDocumentRequest review)
        {
            var response = await _repo.CreateReviewDocumentAsync(review);
            if (response)
            {
                return Ok("Review saved successfully");
            }

            return BadRequest("Unable to save review");
        }

    }
}
