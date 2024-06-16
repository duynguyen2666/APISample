using API.Database;
using API.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly IHashingService _hashingService;
        private readonly APIDbContext _dbContext;

        public UserService(ITokenService tokenService, IHashingService hashingService, APIDbContext dbContext)
        {
            _tokenService = tokenService;
            _hashingService = hashingService;
            _dbContext = dbContext;
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            var pwdHash = _hashingService.ComputeHash(password);
            var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Username == username && e.Password == pwdHash);
            if(user == null)
            {
                return string.Empty;
            }
            return _tokenService.GenerateToken(user);
        }
    }
}
