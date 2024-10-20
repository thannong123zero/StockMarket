using StockMarket.Server._Convergence.DataAccess.DTOs;
using StockMarket.Server._Convergence.DataAccess.IRepositories;
using System.Linq.Expressions;

namespace StockMarket.Server._Convergence.DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<CompanyDTO>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
