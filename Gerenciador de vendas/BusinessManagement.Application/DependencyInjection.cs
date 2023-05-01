using BusinessManagement.Application.Interactor;
using BusinessManagement.Application.Interactor.interfaces;
using BusinessManagement.Application.RegionService.Register;
using BusinessManagement.Application.SellerService.Create;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplications(this IServiceCollection Services) 
        {

            Services.AddTransient<IRegionIbgeInteractor, RegionIbgeInteractor>();
            Services.AddTransient<ISearchByZipCode, SearchByZipCode>();
            Services.AddScoped<IRegisterRegionService, RegisterRegionService>();
            Services.AddTransient<ICreateSellerService, CreateSellerService>();

            return Services;
        }
    }
}
