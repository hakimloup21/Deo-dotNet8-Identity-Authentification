using Microsoft.AspNetCore.Mvc;

namespace DotNetCore8AuthDemo.Controllers
{
    public class DemoController : BaseController
    {
        public DemoController() { }
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Server is Running at" + DateTime.UtcNow);
        }
    }
}
