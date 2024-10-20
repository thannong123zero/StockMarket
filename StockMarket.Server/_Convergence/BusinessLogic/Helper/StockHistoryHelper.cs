using AutoMapper;
using Newtonsoft.Json;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.DataAccess;
using StockMarket.Server._Convergence.DataAccess.DTOs;
using StockMarket.Server._Convergence.Services.FetchDataServiceAPIs;
using StockMarket.Server.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockMarket.Server._Convergence.BusinessLogic.Helper
{
    public class StockHistoryHelper : IStockHistoryHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        public const string filePath = @".\wwwroot\StockHistory.json";
        private readonly IMapper _mapper;
        public StockHistoryHelper(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task FetchData()
        {
            FetchDataAPI fetchData = new FetchDataAPI();
            var data = await fetchData.FetchData();
            if (data == null)
                return;
            int length = data.t.Count;
            for (int i = 0; i < length; i++)
            {
                StockHistoryDTO stockHistoryDTO = new StockHistoryDTO
                {
                    CompanyId = 1,
                    Close = data.c[i],
                    High = data.h[i],
                    Low = data.l[i],
                    Open = data.o[i],
                    Date = data.t[i] * 1000,
                    Volume = data.v[i]
                };
                _unitOfWork.StockHistoryRepository.Create(stockHistoryDTO);
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockHistoryViewModel>> GetAllAsync()
        {        
            var data = await _unitOfWork.StockHistoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StockHistoryViewModel>>(data);
        }
        public List<StockHistoryViewModel> GetStockHistory()
        {
            List<StockHistoryViewModel> stockHistory = new List<StockHistoryViewModel>();
            using StreamReader reader = new(filePath);
            string json = reader.ReadToEnd();
            stockHistory = JsonConvert.DeserializeObject<List<StockHistoryViewModel>>(json);
            return stockHistory;
        }
    }
}