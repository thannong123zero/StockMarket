using AutoMapper;
using StockMarket.Server._Convergence.DataAccess.DTOs;
using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.Services
{
    public class SignUpAutoMap : Profile
    {
        public SignUpAutoMap()
        {
            CreateMap<StockHistoryDTO, StockHistoryViewModel>().ReverseMap();
            CreateMap<CompanyDTO, CompanyViewModel>().ReverseMap();
        }
    }
}
