namespace API.Services.Abstractions
{
    public interface IHashingService
    {
        string ComputeHash(string input);
    }
}
