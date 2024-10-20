﻿using AutoMapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.DataAccess;
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
            throw new NotImplementedException();
        }

        public Task CreateAsync(StockHistoryViewModel model)
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

        public IEnumerable<StockHistoryViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StockHistoryViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public StockHistoryViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StockHistoryViewModel> GetByIdAsync(int id)
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
