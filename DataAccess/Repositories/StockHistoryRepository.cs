using DataAccess.DTOs;
using DataAccess.IRepositories;

namespace DataAccess.Repositories
{
    public class StockHistoryRepository : GenericRepository<StockHistoryDTO>, IStockHistoryRepository
    {
        public StockHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
