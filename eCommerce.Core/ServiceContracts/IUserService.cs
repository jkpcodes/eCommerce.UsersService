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
}