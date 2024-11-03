using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace StockMarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid model state");
                return BadRequest(ModelState);
            }
            return Ok("LoginController.Login");
        }
    }
}