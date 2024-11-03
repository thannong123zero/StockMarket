using BusinessLogic.Helper;
using BusinessLogic.IHelper;
using DataAccess;

namespace StockMarket.Server
{
    public static class SignUpService
    {
        public static IServiceCollection SignUp(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICompanyHelper, CompanyHelper>();
            services.AddTransient<IStockHistoryHelper, StockHistoryHelper>();

            return services;
        }
    }
}
