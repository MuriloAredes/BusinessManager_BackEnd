using BusinessManagement.Infra.Data;
using BusinessManagement.Infra.Persistencia;
using BusinessManagement.Infra.Persistencia.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessManagement.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection Services) 
        {

            Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            Services.AddScoped<IMicroRegionRepository, MicroRegionRepository>();
            Services.AddScoped<IRegionRepository, RegionRepository>();

            return Services;
        }
    }
}
