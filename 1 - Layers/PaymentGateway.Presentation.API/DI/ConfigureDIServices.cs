using AcquiringBank.Infrastructure.Abstraction;
using PaymentGateway.Application.Services.Services;
using PaymentGateway.Domain.Core.Entities;
using PaymentGateway.Domain.Core.Gateways;
using PaymentGateway.Domain.Core.Repositories;
using PaymentGateway.Infrastructure.Database.Repositories;

namespace PaymentGateway.Presentation.API.DI
{
    public static class ConfigureDIServices
    {
        public static IServiceCollection AddAPIGatewayDependencies(this IServiceCollection services)
        {
            //Add AcquiringBank Gateway Implementation

            services.AddSingleton<IAcquiringBankGateway, AcquiringBankGatewayDummyImplementation>();


            //Add CardInfo Repository

            services.AddTransient<ICardInfoRepository, CardInfoRepository>();

            //Add Domain Enitities

            services.AddTransient<ICardInfoDomainEntity, CardInfoDomainEntity>();
            services.AddTransient<IPaymentDomainEntity, PaymentDomainEntity>();

            //Add Application Services 

            services.AddTransient<ICardInfoService, CardInfoService>();
            services.AddTransient<IPaymentService, PaymentService>();

            return services;
        }
    }
}
