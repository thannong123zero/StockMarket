using AutoMapper;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.DataAccess;
using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.BusinessLogic.Helper
{
    public class CompanyHelper : ICompanyHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyHelper(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public CompanyViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }

        public Task RestoreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
