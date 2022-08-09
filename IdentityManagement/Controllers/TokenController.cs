using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace IdentityManagement.Controllers;

public class TokenController : Controller
{
    readonly ITokenAcquisition _tokenAcquisition;

    public TokenController(ITokenAcquisition tokenAcquisition)
    {
        _tokenAcquisition = tokenAcquisition;
    }

    [HttpPost]
    public async Task<IActionResult> Generate(string[] scopes)
    {
        string accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
        return Ok(accessToken);
    }

}
