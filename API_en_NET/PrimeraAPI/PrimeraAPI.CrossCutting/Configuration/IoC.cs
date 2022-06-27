using PrimeraAPI.Application.Contracts.Services;
using PrimeraAPI.Application.Services;
using PrimeraAPI.CrossCutting.Contracts.Services;
using PrimeraAPI.CrossCutting.Services;
using PrimeraAPI.DataAccess;
using PrimeraAPI.DataAccess.Contracts;
using PrimeraAPI.DataAccess.Contracts.Repositories;
using PrimeraAPI.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PrimeraAPI.CrossCutting.Configuration
{
    public static class IoC
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {

            string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(
                item =>
                {
                    item.UseMySql(
                 mySqlConnectionStr,
                 ServerVersion.AutoDetect(mySqlConnectionStr)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).EnableSensitiveDataLogging();
                }, ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductLineService, ProductLineService>();
            services.AddTransient<IProductLineRepository, ProductLineRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IOfficeService, OfficeService>();
            services.AddTransient<ICacheService, CacheService>();

            return services;
        }
    }
}
