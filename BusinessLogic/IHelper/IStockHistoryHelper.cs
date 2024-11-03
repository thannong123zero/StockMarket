using Common.ViewModels;

namespace BusinessLogic.IHelper
{
    public interface IStockHistoryHelper
    {
        public Task<IEnumerable<StockHistoryViewModel>> GetAllAsync(string symbol);
        public Task<bool> FetchData(string symbol, DateTime from, DateTime to);
    }
}
