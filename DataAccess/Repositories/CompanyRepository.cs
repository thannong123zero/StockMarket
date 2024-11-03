using DataAccess.DTOs;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<CompanyDTO>, ICompanyRepository
    {
        private DbSet<CompanyDTO> _dbSet;
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = context.Set<CompanyDTO>();
        }

        public async Task<CompanyDTO> GetCompanyBySymbolAsync(string symbol)
        {
            return await _context.Set<CompanyDTO>().FirstOrDefaultAsync(x => x.Symbol == symbol);
        }
    }
}
