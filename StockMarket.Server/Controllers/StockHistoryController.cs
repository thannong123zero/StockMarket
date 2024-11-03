using BusinessLogic.IHelper;
using Microsoft.AspNetCore.Mvc;


namespace StockMarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockHistoryController : ControllerBase
    {
        private readonly IStockHistoryHelper _stockHistoryHelper;
        public StockHistoryController(IStockHistoryHelper stockHistoryHelper)
        {
            _stockHistoryHelper = stockHistoryHelper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string symbol)
        {
            var data = await _stockHistoryHelper.GetAllAsync(symbol);
            return Ok(data);
        }
        [HttpGet("FetchData")]
        public async Task<IActionResult> FetchData(string symbol, DateTime from, DateTime to)
        {
            bool check = await _stockHistoryHelper.FetchData(symbol,from,to);
            if (!check)
                return BadRequest();
            return Ok();
        }
        //[HttpGet("Get/{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok("CompanyController.Get");
        //}
        //[HttpPost("Create")]
        //public IActionResult Create()
        //{
        //    return Ok("CompanyController.Add");
        //}
        //[HttpPut("Update")]
        //public IActionResult Update()
        //{
        //    return Ok("CompanyController.Update");
        //}
        //[HttpDelete("Delete/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    return Ok("CompanyController.Delete");
        //}
    }
}
