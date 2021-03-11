using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.DTOs.Response;
using RemoteTestingApp.Core.Entities;
using RemoteTestingApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.DocumentUploadRepository
{
    
    public class UploadDocumentRepository : IUploadDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileLogger _logger;
        private readonly IMapper _mapper;

        public UploadDocumentRepository(ApplicationDbContext context,
            IFileLogger logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddUploadDocumentAsync(UploadCertificatesRequestDTO docs)
        {
            try
            {
                var request = _mapper.Map<UploadedDocument>(docs);
                var response = await _context.UploadedDocuments.AddAsync(request);
                var result = await _context.SaveChangesAsync() > 0;
                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message, "AddUploadDocumentAsync");
                return default;
            }

        }
        public async Task<UploadedDocumentResponseDTO> GetUploadedDocumentAsync(Guid UserUniqueIdentifier)
        {
            try
            {
                var response = await _context.UploadedDocuments.SingleOrDefaultAsync(x => x.CandidateUniqueIdentifier == UserUniqueIdentifier);
                var result = _mapper.Map<UploadedDocumentResponseDTO>(response);
                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message, "AddUploadDocumentAsync");
                return default;
            }

        }
    }
}
