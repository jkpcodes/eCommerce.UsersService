using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using Dapper;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        // Generate unique user ID for the user
        user.UserId = Guid.NewGuid();

        // SQL Query to insert user data into the database
        string query = @"INSERT INTO public.""Users"" (""UserId"", ""Email"", ""PersonName"", ""Gender"", ""Password"")
            VALUES (@UserId, @Email, @PersonName, @Gender, @Password)";

        int rowAffected = await _dbContext.Connection.ExecuteAsync(query, user);

        if (rowAffected == 0)
            return null; // If no rows were affected, return null

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        // SQL Query to select user by email and password
        string query = @"SELECT * FROM public.""Users"" WHERE ""Email""=@Email AND ""Password""=@Password";

        ApplicationUser? user = await _dbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>
            (query, new { Email = email, Password = password });

        if (user == null)
        {
            return null; // If no user found, return null
        }

        return user;
    }
}