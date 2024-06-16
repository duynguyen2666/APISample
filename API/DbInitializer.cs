
using API.Database;
using API.Services.Abstractions;

namespace API
{
    public class DbInitializer
    {
        private readonly IHashingService _hashingService;
        private readonly APIDbContext _dbContext;

        public DbInitializer(IHashingService hashingService, APIDbContext dbContext)
        {
            _hashingService = hashingService;
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            if (_dbContext.Users.Any())
            {
                return;
            }

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Users.Add(new User
                    {
                        Username = "admin",
                        Password = _hashingService.ComputeHash("12345678x@X"),
                        Role = "Admin"
                    });

                    _dbContext.Users.Add(new User
                    {
                        Username = "tthanhphong",
                        Password = _hashingService.ComputeHash("123456789x@X"),
                        Role = "Staff"
                    });
                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
