using Application.UseCase.User.Create;
using Microsoft.AspNetCore.Mvc;
using UserApi.Base;

namespace UserApi;

public class UserController : ApiControllerBase
{
    [HttpPost("CreateUser")]
    public async Task<ActionResult> CreateUser(CreateUserRequest request)
    {
        var response = await Mediator.Send(request);

        if (response.HasError)
            return BadRequest(response);

        return Ok();
    }
}