using DotNetCore8AuthDemo.Controllers.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore8AuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] IdentityUser user)
        {
            return Ok(_identityService.Register(user));
        }
    }
}
