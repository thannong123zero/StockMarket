using AutoMapper;
using BusinessLogic.IHelper;
using Common.Services.FetchDataServiceAPIs;
using Common.ViewModels;
using DataAccess;
using DataAccess.DTOs;

namespace BusinessLogic.Helper
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
        public async Task<bool> FetchData(string symbol, DateTime from, DateTime to)
        {
            symbol = symbol.Trim().ToUpper();
            var company = await _unitOfWork.CompanyRepository.GetCompanyBySymbolAsync(symbol);
            if (company == null)
                return false;
            long fromUnixTime = new DateTimeOffset(from).ToUnixTimeSeconds();
            long toUnixTime = new DateTimeOffset(to).ToUnixTimeSeconds();

            var stock = await _unitOfWork.StockHistoryRepository.GetAllAsync(filter: s => s.Date >= fromUnixTime * 1000 && s.CompanyId == company.Id);
            if (stock.Count() > 0)
                return false;

            FetchDataAPI fetchData = new FetchDataAPI();
            var data = await fetchData.FetchData(company.Symbol, fromUnixTime.ToString(), toUnixTime.ToString());
            if (data == null)
                return false;
            int length = data.t.Count;
            for (int i = 0; i < length; i++)
            {
                StockHistoryDTO stockHistoryDTO = new StockHistoryDTO
                {
                    CompanyId = company.Id,
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
            return true;
        }
        public async Task<IEnumerable<StockHistoryViewModel>> GetAllAsync(string symbol)
        {
            symbol = symbol.Trim().ToUpper();
            var company = await _unitOfWork.CompanyRepository.GetCompanyBySymbolAsync(symbol);
            if (company == null)
                return null;
            var data = await _unitOfWork.StockHistoryRepository.GetAllAsync(filter: s => s.CompanyId == company.Id);
            return _mapper.Map<IEnumerable<StockHistoryViewModel>>(data);
        }
    }
}