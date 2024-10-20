using Microsoft.AspNetCore.Http.Extensions;
using StockMarket.Server._Convergence.BusinessLogic.Helper;
using StockMarket.Server._Convergence.BusinessLogic.IHelper;
using StockMarket.Server._Convergence.DataAccess;
using System.Runtime.CompilerServices;

namespace StockMarket.Server._Convergence.Services
{
    public static class SignUpService
    {
        public static IServiceCollection SignUp(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompanyHelper, CompanyHelper>();
            services.AddScoped<IStockHistoryHelper, StockHistoryHelper>();

            return services;
        }
    }
}
