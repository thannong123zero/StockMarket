using DataAccess.DTOs;

namespace DataAccess.IRepositories
{
    public interface ICompanyRepository : IGenericRepository<CompanyDTO>
    {
        public Task<CompanyDTO> GetCompanyBySymbolAsync(string symbol);
    }
}
