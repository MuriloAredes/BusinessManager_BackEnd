using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Domain.Dtos
{

    public class Region
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("sigla")]
        public string Sigla { get; set; } = String.Empty;
        [JsonProperty("nome")]
        public string Nome { get; set; } = String.Empty;
    }


    public class MicroRegiaoDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("sigla")]
        public string Sigla { get; set; } = String.Empty;
        [JsonProperty("nome")]
        public string Nome { get; set; } = String.Empty;
        [JsonProperty("regiao")]
        public Region? Region { get; set; }
    }

    
}
