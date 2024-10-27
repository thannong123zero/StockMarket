using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.BusinessLogic.IHelper
{
    public interface IStockHistoryHelper 
    {
        public Task<IEnumerable<StockHistoryViewModel>> GetAllAsync(string symbol);
        public Task<bool> FetchData(string symbol, DateTime from, DateTime to);
    }
}
