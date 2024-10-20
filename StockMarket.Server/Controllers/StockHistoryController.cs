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

        [HttpGet]
        public IActionResult Get()
        {
            var data = _stockHistoryHelper.GetStockHistory();   
            return Ok(data);
        }
    }
}
