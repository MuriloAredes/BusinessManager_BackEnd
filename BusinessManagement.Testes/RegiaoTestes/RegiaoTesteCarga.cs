using BusinessManagement.Application.RegionService.Register;
using Xunit;
namespace BusinessManagement.Testes.RegiaoTestes
{
    public class RegiaoTesteCarga : IClassFixture<IRegisterRegionService>
    {
        private readonly IRegisterRegionService _regitrarCarga;


        [Fact]
        public async void CargaRegion()
        {

            var result = await _regitrarCarga.RegisterRegion();

            Assert.NotNull(result);
        }
    }
}
