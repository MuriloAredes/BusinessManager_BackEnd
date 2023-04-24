using BusinessManagement.Application.RegionService.Register;
using BusinessManagement.Domain.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using ServiceStack;

namespace BusinessManagement.Testes.RegiaoTestes
{
  
    public class RegiaoTesteCarga
    {
        private IRegisterRegionService _registerRegionService ;


        [SetUp]
        public void setup()
        {
            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices(
                services =>
                            services.AddScoped<IRegisterRegionService, RegisterRegionService>());

            var app = builder.Build();

            _registerRegionService = app.Services.GetRequiredService<IRegisterRegionService>();
        }

        [Fact]
        public async void CargaRegion()
        {
            var _registerRegion = new TesteRegiao(_registerRegionService);

            var result = await _registerRegion.TestarCargaRegion();


            Xunit.Assert.NotNull(result);
        }
    }

    public class TesteRegiao
    {

        private readonly IRegisterRegionService _registerRegionService;
        public TesteRegiao(IRegisterRegionService registerRegionService)
        {
            _registerRegionService = registerRegionService; 
        }

        public async Task<MensagemDto> TestarCargaRegion() 
        {
            return await _registerRegionService.RegisterRegion();
        }
    }
}
