using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PasswordHasherandJwtTokenProvider.Interfaces;
using RemoteTestingApp.Core.DTOs.Request;
using RemoteTestingApp.Core.DTOs.Response;
using RemoteTestingApp.Core.Entities;
using RemoteTestingApp.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace RemoteTestingApp.Infrastructure.DataAccess.Repository.AuthRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _hasher;
        private readonly IFileLogger _logger;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthenticationRepository(ApplicationDbContext context, IPasswordHasher hasher,
            IFileLogger logger, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _hasher = hasher;
            _logger = logger;
            _config = config;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(RegisterRequestDTO request)
        {
            try
            {
                if (await UserExistsAsync(request.Email)) return false;
                _logger.LogInfo(request.Email + " Creating user...", "RegisterAsync");
                var personalEncrypt = _config.GetSection("personalizedEncrypter").Value;
                byte[] passwordhash, passwordSalt;
                var hashvalue = _hasher.PasswordHashAndSaltToReturn(request.password, personalEncrypt);
                passwordhash = hashvalue.PasswordHash;
                passwordSalt = hashvalue.PasswordSalt;
                var newRegister = _mapper.Map<Register>(request);
                newRegister.passwordHash = passwordhash;
                newRegister.passwordSalt = passwordSalt;
                newRegister.UserUniqueIdentifier = Guid.NewGuid();
                await _context.AddAsync(newRegister);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message + " Error Occured", "RegisterAsync");
            }
            return false;
        }

        public async Task<RegisteredUserResponseDTO> GetRegisteredUser(string email)
        {
            try
            {
                var user = await _context.Registers.SingleOrDefaultAsync(x => x.Email.ToLower()== email.ToLower().Trim());
                var result = new RegisteredUserResponseDTO { Email = user.Email, FirstName = user.FirstName, UserUniqueID = user.UserUniqueIdentifier };
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "GetRegisteredUser");
                return default;
            }
            
        }

        public async Task<bool> UserExistsAsync(string username)
        {

            try
            {
                if (await _context.Registers.AnyAsync(x => x.Email.ToLower() == username.Trim().ToLower()))
                {
                    _logger.LogInfo(username + " already exists", "UserExistsAsync");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + "Inner Exception" + ex.InnerException.Message, "  AuthenticationRepositoryUserExistsAsync");
                return false;
            }


        }

        public async Task<bool> LoginAsync(SigninRequestDTO request)
        {
            _logger.LogInfo(request.Email + $" Attempts Login @{DateTime.Now}", "LoginAsync");

            try
            {
                var personalEncrypt = _config.GetSection("personalizedEncrypter").Value;
                var finder = await _context.Registers.FirstOrDefaultAsync(x => x.Email.ToLower()==request.Email.Trim().ToLower());
                if (finder == null)
                {
                    _logger.LogInfo(request.Email + " Login Denied reason: user Email does not exist", "LoginAsync");
                    return false;
                }
                if (!_hasher.VerifyPasswordHash(request.Password, finder.passwordHash, finder.passwordSalt,personalEncrypt))
                {
                    _logger.LogInfo(request.Email + " Login Denied reason: password incorrect", "LoginAsync");

                    return false;

                }


                _logger.LogInfo(request.Email + " Login Successful", "LoginAsync");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + "Inner Exception" + ex.InnerException.Message, "  AuthenticationRepositoryLoginAsync");
                return false;
            }



        }
    }
}
