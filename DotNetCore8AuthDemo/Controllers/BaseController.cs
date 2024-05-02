using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore8AuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize()]
    public class BaseController : ControllerBase
    {

    }
}
