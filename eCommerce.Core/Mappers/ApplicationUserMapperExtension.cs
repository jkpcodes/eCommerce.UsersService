using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public static class ApplicationUserMapperExtension
{
    /// <summary>
    /// Adds the extension method to map an ApplicationUser to an AuthenticationResponse
    /// </summary>
    public static AuthenticationResponse MapToAuthenticationResponse(this ApplicationUser user, string token, bool success)
    {
        return new AuthenticationResponse
        (
            user.UserID,
            user.Email,
            user.PersonName,
            user.Gender,
            token,
            success
        );
    }

    /// <summary>
    /// Adds the extension method to map an ApplicationUser to a UserDTO object
    /// </summary>
    public static UserDTO MapToUserDTO(this ApplicationUser user)
    {
        return new UserDTO
        (
            user.UserID,
            user.Email,
            user.PersonName,
            user.Gender
        );
    }
}