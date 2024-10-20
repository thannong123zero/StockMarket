using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Server._Convergence.BusinessLogic.Helper;
using StockMarket.Server.Models;

namespace StockMarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockHistoryController : ControllerBase
    {
        private readonly StockHistoryHelper _stockHistoryHelper;
        public StockHistoryController(StockHistoryHelper stockHistoryHelper)
        {
            _stockHistoryHelper = stockHistoryHelper;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var data = _stockHistoryHelper.GetAll();   
            return Ok(data);
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
