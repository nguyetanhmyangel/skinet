using Api.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("errors/{code}")]
//When applied to a public method on a controller, it prevents that method from appearing in the swagger ui.
//refer: https://code-maze.com/aspnetcore-how-to-hide-endpoint-in-swagger/
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseApiController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}
