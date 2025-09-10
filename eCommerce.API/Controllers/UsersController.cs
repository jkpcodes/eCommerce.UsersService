using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userID:guid}")]
    public async Task<ActionResult<UserDTO?>> GetUserByUserID(Guid userID)
    {
        if (userID == Guid.Empty)
        {
            return BadRequest("Invalid user ID");
        }

        var response = await _userService.GetUserByUserID(userID);

        if (response == null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpGet("search/userids")]
    public async Task<ActionResult<List<UserDTO?>>> GetUsersByUserIDs([FromQuery] List<Guid> ids)
    {
        if (ids == null || !ids.Any() || ids.Any(id => id == Guid.Empty))
        {
            return BadRequest("Invalid user IDs");
        }
        var response = await _userService.GetUsersByUserIDs(ids);
        if (response == null || !response.Any())
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}