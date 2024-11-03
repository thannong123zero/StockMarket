using AutoMapper;
using Common.ViewModels;
using DataAccess.DTOs;

namespace StockMarket.Server
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
