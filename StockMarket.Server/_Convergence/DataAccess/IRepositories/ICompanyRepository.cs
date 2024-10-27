using StockMarket.Server._Convergence.DataAccess.DTOs;

namespace StockMarket.Server._Convergence.DataAccess.IRepositories
{
    public interface ICompanyRepository : IGenericRepository<CompanyDTO>
    {
        public Task<CompanyDTO> GetCompanyBySymbolAsync(string symbol);
    }
}
