using StockMarket.Server._Convergence.DataAccess.IRepositories;

namespace StockMarket.Server._Convergence.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IStockHistoryRepository StockHistoryRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
