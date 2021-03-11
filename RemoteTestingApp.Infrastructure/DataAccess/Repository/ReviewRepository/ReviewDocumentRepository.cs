using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.Entities;
using RemoteTestingApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.ReviewRepository
{
    public class ReviewDocumentRepository : IReviewDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileLogger _logger;
        private readonly IMapper _mapper;

        public ReviewDocumentRepository(ApplicationDbContext context,
            IFileLogger logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CreateReviewDocumentAsync(ReviewCompanyDocumentRequest request)
        {
            try
            {

                var newUpdate = _mapper.Map<ReviewCompanyDocument>(request);
                newUpdate.DocumentUnquieID = Guid.NewGuid();


                await _context.ReviewCompanyDocuments.AddAsync(newUpdate);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + "Inner Exception" + ex.InnerException.Message, "   CreateReviewDocumentAsync");
                return default;
            }

        }

        public async Task<CompanyDocument> GetCompanyDocumentAsync(int id)
        {
            try
            {
                var document = await _context.CompanyDocuments.SingleOrDefaultAsync(x => x.Id == id);
                return document;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "GetCompanyDocumentAsync");
                return default;
                
            }
        }





    }
}
