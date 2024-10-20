using StockMarket.Server._Convergence.DataAccess.IRepositories;
using StockMarket.Server._Convergence.DataAccess.Repositories;

namespace StockMarket.Server._Convergence.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private bool disposed = false;

        public IStockHistoryRepository StockHistoryRepository { get; private set; }

        public ICompanyRepository CompanyRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
            StockHistoryRepository = new StockHistoryRepository(context);
            CompanyRepository = new CompanyRepository(context);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }
        public void Commit()
        {
            throw new NotImplementedException();
        }
        public void Rollback()
        {
            throw new NotImplementedException();
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
