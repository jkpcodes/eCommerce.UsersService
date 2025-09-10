using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUserRepository
{
    /// <summary>
    /// Adds a new user to the database and returns the created user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    /// <summary>
    /// Retrieves a user by their email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    /// <summary>
    /// Retrieves a user by their unique user ID.
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByUserID(Guid userID);


    /// <summary>
    /// Retrieves a list of users by their unique user ID.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<List<ApplicationUser>> GetUsersByUserIDs(List<Guid> ids);
}