using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.Mappers;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);
        if (user == null)
        {
            return null;
        }

        return user.MapToAuthenticationResponse("token", true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        ApplicationUser addUser = request.MapToApplicationUser();

        ApplicationUser? createdUser = await _userRepository.AddUser(addUser);

        if (createdUser == null)
        {
            return null;
        }

        return createdUser.MapToAuthenticationResponse("token", true);
    }
}