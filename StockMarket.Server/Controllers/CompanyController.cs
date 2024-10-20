using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockMarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok("CompanyController.Get");
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok("CompanyController.Get");
        }
        [HttpPost("Create")]
        public IActionResult Create()
        {
            return Ok("CompanyController.Add");
        }
        [HttpPut("Update")]
        public IActionResult Update()
        {
            return Ok("CompanyController.Update");
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("CompanyController.Delete");
        }
    }
}
