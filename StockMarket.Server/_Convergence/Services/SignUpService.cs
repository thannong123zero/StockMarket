using Microsoft.AspNetCore.Http.Extensions;
using StockMarket.Server._Convergence.BusinessLogic.Helper;
using System.Runtime.CompilerServices;

namespace StockMarket.Server._Convergence.Services
{
    public static class SignUpService
    {
        public static IServiceCollection SignUp(this IServiceCollection services)
        {
            services.AddScoped<StockHistoryHelper>();
            return services;
        }
    }
}
