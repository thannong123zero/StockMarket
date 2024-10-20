using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.BusinessLogic.IHelper
{
    public interface IStockHistoryHelper 
    {
        public Task<IEnumerable<StockHistoryViewModel>> GetAllAsync();
        public Task FetchData();
    }
}
