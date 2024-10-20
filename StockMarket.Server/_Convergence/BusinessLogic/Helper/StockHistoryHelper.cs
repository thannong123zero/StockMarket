using AutoMapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.DataAccess;
using StockMarket.Server._Convergence.DataAccess.DTOs;
using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.BusinessLogic.Helper
{
    public class StockHistoryHelper : IStockHistoryHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StockHistoryHelper(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(StockHistoryViewModel model)
        {
            var data = _mapper.Map<StockHistoryDTO>(model);
            _unitOfWork.StockHistoryRepository.Create(data);
            _unitOfWork.SaveChanges();
        }

        public async Task CreateAsync(StockHistoryViewModel model)
        {
            var data = _mapper.Map<StockHistoryDTO>(model);
           await _unitOfWork.StockHistoryRepository.CreateAsync(data);
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

        public IEnumerable<StockHistoryViewModel> GetAll()
        {
            var data = _unitOfWork.StockHistoryRepository.GetAll();
            return _mapper.Map<IEnumerable<StockHistoryViewModel>>(data);
        }

        public async Task<IEnumerable<StockHistoryViewModel>> GetAllAsync()
        {
            var data = await _unitOfWork.StockHistoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StockHistoryViewModel>>(data);
        }

        public StockHistoryViewModel GetById(int id)
        {
            var data = _unitOfWork.StockHistoryRepository.GetById(id);
            return _mapper.Map<StockHistoryViewModel>(data);
        }

        public async Task<StockHistoryViewModel> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.StockHistoryRepository.GetByIdAsync(id);
            return _mapper.Map<StockHistoryViewModel>(data);
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

        public void Update(StockHistoryViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StockHistoryViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
