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
        user.UserID = Guid.NewGuid();

        // SQL Query to insert user data into the database
        string query = @"INSERT INTO public.""Users"" (""UserID"", ""Email"", ""PersonName"", ""Gender"", ""Password"")
            VALUES (@UserID, @Email, @PersonName, @Gender, @Password)";

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

        return user;
    }

    public async Task<ApplicationUser?> GetUserByUserID(Guid userID)
    {
        string query = @"SELECT * FROM public.""Users"" WHERE ""UserID""=@UserID";
        var parameters = new { UserID = userID };

        ApplicationUser? user = await _dbContext.Connection
            .QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }

    public async Task<List<ApplicationUser>> GetUsersByUserIDs(List<Guid> ids)
    {
        string query = @"SELECT * FROM public.""Users"" WHERE ""UserID"" = ANY(@Ids)";
        var parameters = new { Ids = ids.ToArray() };

        var results = await _dbContext.Connection
            .QueryAsync<ApplicationUser>(query, parameters);

        if (results == null)
            return new List<ApplicationUser>();

        return results.ToList();
    }
}