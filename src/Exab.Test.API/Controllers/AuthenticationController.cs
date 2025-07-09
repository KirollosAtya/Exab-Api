using Exab.Test.Application.Modules.Login.Command.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exab.Test.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public virtual async Task<IActionResult> Login(UserLoginCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
