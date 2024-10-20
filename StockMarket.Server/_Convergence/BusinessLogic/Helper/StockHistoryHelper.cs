using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.BusinessLogic.Helper
{
    public class StockHistoryHelper
    {
        public const string filePath = @".\wwwroot\StockHistory.json";
        public List<StockHistoryViewModel> GetStockHistory()
        {
            List<StockHistoryViewModel> stockHistory = new List<StockHistoryViewModel>();
            using StreamReader reader = new(filePath);
            string json = reader.ReadToEnd();
            stockHistory = JsonConvert.DeserializeObject<List<StockHistoryViewModel>>(json);
            return stockHistory;
        }
    }
}
