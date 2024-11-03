using DataAccess.IRepositories;

namespace DataAccess
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
