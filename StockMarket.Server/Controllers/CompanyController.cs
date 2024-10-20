using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server.Models;

namespace StockMarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyHelper _companyHelper;
        public CompanyController(ICompanyHelper companyHelper)
        {
            _companyHelper = companyHelper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _companyHelper.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok("CompanyController.Get");
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _companyHelper.CreateAsync(model);
            return Ok("CompanyController.Add");
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] CompanyViewModel model)
        {
            _companyHelper.Update(model);
            return Ok("CompanyController.Update");
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("CompanyController.Delete");
        }
    }
}
