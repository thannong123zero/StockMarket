using AutoMapper;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.DataAccess;
using StockMarket.Server._Convergence.DataAccess.DTOs;
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
            var data = _mapper.Map<CompanyDTO>(model);
            _unitOfWork.CompanyRepository.Create(data);
            _unitOfWork.SaveChanges();
        }

        public async Task CreateAsync(CompanyViewModel model)
        {
            var data = _mapper.Map<CompanyDTO>(model);
            await _unitOfWork.CompanyRepository.CreateAsync(data);
            await _unitOfWork.SaveChangesAsync();
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
            var data = _unitOfWork.CompanyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyViewModel>>(data);
        }

        public async Task<IEnumerable<CompanyViewModel>> GetAllAsync()
        {
            var data = await _unitOfWork.CompanyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyViewModel>>(data);
        }

        public CompanyViewModel GetById(int id)
        {
            var data = _unitOfWork.CompanyRepository.GetById(id);
            return _mapper.Map<CompanyViewModel>(data);
        }

        public async Task<CompanyViewModel> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            return _mapper.Map<CompanyViewModel>(data);
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
            var data = _unitOfWork.CompanyRepository.GetById(model.Id);
            if(data == null)
            {
                throw new Exception("Company not found");
            }
            data.Name = model.Name;
            data.Symbol = model.Symbol;
            _unitOfWork.SaveChanges();
        }

        public async Task UpdateAsync(CompanyViewModel model)
        {
            var data = await _unitOfWork.CompanyRepository.GetByIdAsync(model.Id);
            if(data == null)
            {
                throw new Exception("Company not found");
            }
            data.Name = model.Name;
            data.Symbol = model.Symbol;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
