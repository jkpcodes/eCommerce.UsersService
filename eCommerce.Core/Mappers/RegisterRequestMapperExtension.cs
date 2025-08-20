using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public static class RegisterRequestMapperExtension
{
    /// <summary>
    /// Adds the extension method to map an RegisterRequest to an ApplicationUser
    /// </summary>
    public static ApplicationUser MapToApplicationUser(this RegisterRequest request)
    {
        return new ApplicationUser
        {
            Email = request.Email,
            Password = request.Password,
            PersonName = request.PersonName,
            Gender = request.Gender.ToString()
        };
    }
}