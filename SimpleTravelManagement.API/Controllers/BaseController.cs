using Microsoft.AspNetCore.Mvc;

namespace SimpleTravelManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result) => 
        result is null ? NotFound(result) : Ok(result);
}
 