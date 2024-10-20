using StockMarket.Server._Convergence.DataAccess.DTOs;
using StockMarket.Server._Convergence.DataAccess.IRepositories;

namespace StockMarket.Server._Convergence.DataAccess.Repositories
{
    public class StockHistoryRepository : GenericRepository<StockHistoryDTO>, IStockHistoryRepository
    {
        public StockHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
