using BusinessManagement.Application.Interactor.interfaces;
using BusinessManagement.Domain.Dtos;
using Newtonsoft.Json;

namespace BusinessManagement.Application.Interactor
{
    public class RegionIbgeInteractor : IRegionIbgeInteractor
    {
        public async Task<List<MicroRegiaoDto>> GetAllRegion()
        {
            using var http = new HttpClient();

            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=a";
            var json = await http.GetStringAsync(url);

            var regions = JsonConvert.DeserializeObject<List<MicroRegiaoDto>>(json);

            if (regions == null)
                return new List<MicroRegiaoDto>();

            return regions;
        }
    }
}
