namespace API.Services.Abstractions
{
    public interface IUserService
    {
        Task<string> LoginAsync(string username, string password);
    }
}
