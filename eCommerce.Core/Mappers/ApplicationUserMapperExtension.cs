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
            user.UserId,
            user.Email,
            user.PersonName,
            user.Gender,
            token,
            success
        );
    }
}