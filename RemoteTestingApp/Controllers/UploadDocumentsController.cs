using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Services.Interfaces;
using RemoteTestingApp.Infrastructure.DataAccess.Repository.DocumentUploadRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteTestingApp.Controllers
{
    [Authorize]
    [Route("api/Documents/")]
    [ApiController]
    public class UploadDocumentsController : ControllerBase
    {
        private readonly IFileLogger _logger;
        private readonly IUploadDocumentRepository _repo;
        private readonly ITokenProvider _provider;

        public UploadDocumentsController(IFileLogger logger, IUploadDocumentRepository repo,
            ITokenProvider provider)
        {
            _logger = logger;
            _repo = repo;
            _provider = provider;

        }

        [HttpGet("GetUploadedDocuments/{useridentifier}")]
        public async Task<IActionResult> GetDocuments(Guid useridentifier)
        {
            var response = await _repo.GetUploadedDocumentAsync(useridentifier);
            if(response != null)
            {
                return Ok(response);
            }

            return NotFound("Document not found for this user");
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm] UploadCertificatesRequestDTO request)
        {
            var response = await _repo.AddUploadDocumentAsync(request);
            if (response)
            {
                return CreatedAtAction("GetDocuments", new { useridentifier = request.CandidateUniqueIdentifier },"Document upload successful");
            }

            return BadRequest("Unable to save documents please try again");
        }
    }
}
