using DotNetCore8AuthDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNetCore8AuthDemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DemoController : BaseController
    {
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DemoController(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Ping()
        {

            var idUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _db.AppUsers.FirstOrDefault();
            return Ok("Server is Running at" + DateTime.UtcNow + "");
        }
    }
}
