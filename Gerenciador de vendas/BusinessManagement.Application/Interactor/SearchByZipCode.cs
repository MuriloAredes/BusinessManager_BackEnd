using BusinessManagement.Application.Interactor.interfaces;
using BusinessManagement.Domain.Dtos;
using Newtonsoft.Json;

namespace BusinessManagement.Application.Interactor
{
    public class SearchByZipCode : ISearchByZipCode
    {
        public async Task<EnderecoDto> Search(string code)
        {

            using var client = new HttpClient();

            client.BaseAddress = new Uri("https://viacep.com.br");

            var response = await client.GetAsync($"/ws/{code}/json").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var adress = JsonConvert.DeserializeObject<EnderecoDto>(result);

            if (adress == null)
                return new EnderecoDto();

            return adress;
        }
    }
}
