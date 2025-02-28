using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Contracts.User;

namespace Pharmacy.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService service) : ControllerBase
{
    private readonly IUserService service = service;

    [HttpGet]
    public async Task<IActionResult> GetProfile(string id)
    {
        var m = await service.userprofile(id);

        return Ok(m.Value) ;
    }

    [HttpPut]
    public async Task<IActionResult> updateProfile(string id , UpdateUserProfileRequest request)
    {
        var r = await service.Updateprofile(id,request);

        return NoContent();
    }
}
