using Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Identity;

namespace OcelotApiGw.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokensController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokensController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetToken()
    {
        var result = _tokenService.GetToken(new TokenRequest());
        return Ok(result);
    }
}
