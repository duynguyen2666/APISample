using API.Database;

namespace API.Services.Abstractions
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
