using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    /// <summary>
    /// Authenticates a user and returns the authentication response.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest request);

    /// <summary>
    /// Registers a new user and returns the authentication response.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest request);

    /// <summary>
    /// Retrieves a user by their unique user ID.
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    Task<UserDTO?> GetUserByUserID(Guid userID);

    /// <summary>
    /// Retrieves multiple users by their unique user IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<List<UserDTO>> GetUsersByUserIDs(List<Guid> ids);
}