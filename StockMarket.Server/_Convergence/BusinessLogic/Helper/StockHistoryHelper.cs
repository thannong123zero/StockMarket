using AutoMapper;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.DataAccess;
using StockMarket.Server._Convergence.DataAccess.DTOs;
using StockMarket.Server._Convergence.Services.FetchDataServiceAPIs;
using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.BusinessLogic.Helper
{
    public class StockHistoryHelper : IStockHistoryHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StockHistoryHelper(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task FetchData()
        {
            FetchDataAPI fetchData = new FetchDataAPI();
            await fetchData.FetchData();

        }

        public Task<IEnumerable<StockHistoryViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}