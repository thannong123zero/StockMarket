using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Server._Convergence.BusinessLogic.Helper;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.Services.FetchDataServiceAPIs;
using StockMarket.Server.Models;
using System;

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
        public async Task<IActionResult> GetAll()
        {
            var data = await _stockHistoryHelper.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetAll1")]
        public IActionResult GetAll1()
        {
            var data =  _stockHistoryHelper.GetStockHistory();
            return Ok(data);
        }
        [HttpGet("FetchData")]
        public async Task<IActionResult> FetchData()
        {
            await _stockHistoryHelper.FetchData();
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
