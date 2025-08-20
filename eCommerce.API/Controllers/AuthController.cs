using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResponse?>> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
            return BadRequest("Invalid registration data");

        AuthenticationResponse? response = await _userService.Register(registerRequest);

        if (response == null || !response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse?>> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
            return BadRequest("Invalid login data");

        AuthenticationResponse? response = await _userService.Login(loginRequest);

        if (response == null || !response.Success)
            return Unauthorized(response);

        return Ok(response);
    }
}
