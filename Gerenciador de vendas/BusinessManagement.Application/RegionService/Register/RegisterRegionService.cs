using BusinessManagement.Application.Interactor.interfaces;
using BusinessManagement.Domain.Dtos;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Persistencia.Interface;

namespace BusinessManagement.Application.RegionService.Register
{
    public class RegisterRegionService : IRegisterRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMicroRegionRepository _microRegionRepository;
        private readonly IRegionIbgeInteractor _regionInteractor;


        public RegisterRegionService(IRegionRepository regionRepository,
                                     IMicroRegionRepository microRegionRepository,
                                     IRegionIbgeInteractor regionInteractor)
        {
            _regionInteractor = regionInteractor;
            _regionRepository = regionRepository;
            _microRegionRepository = microRegionRepository;
        }
        public async Task<MensagemDto> RegisterRegion()
        {
            var resultRegionsInteractor = await _regionInteractor.GetAllRegion();
            var regionDb = _regionRepository.GetAll().ToList();
            var microRegionDb = _microRegionRepository.GetAll().ToList();


            var microRegionList = resultRegionsInteractor.Select(o =>
            new MicroRegiao
            {
                Nome = o.Nome,
                Sigla = o.Sigla,
                Regiao = new Regiao
                {
                    Nome = o.Region.Nome,
                    Sigla = o.Region.Sigla,
                }
            }).ToList();

            List<Regiao> regionListFilter = new List<Regiao>();
            List<MicroRegiao> microRegionListFilter = new List<MicroRegiao>();

            foreach (var microRegion in microRegionList)
            {
                
                if (!regionDb.Any(e => e.Sigla.Equals(microRegion.Regiao.Sigla)))
                {
                    if (!regionListFilter.Any(o => o.Sigla.Equals(microRegion.Regiao.Sigla)))
                    {
                        regionListFilter.Add(new Regiao  { Nome = microRegion.Nome, Sigla = microRegion.Sigla });
                    }
                }

                if (!microRegionDb.Any(o => o.Sigla.Equals(microRegion.Sigla)))
                {
                    if (!microRegionListFilter.Any(o => o.Nome.Equals(microRegion.Nome)))
                    {
                        microRegionListFilter.Add(new MicroRegiao { Nome = microRegion.Regiao.Nome, Sigla = microRegion.Regiao.Sigla });
                    }
                }

            }

            var microRegionCleanList = microRegionListFilter.Distinct().ToList();
            var regionCleanList = regionListFilter.Distinct().ToList();


            foreach (var item in microRegionCleanList)
            {
                var region = await _regionRepository.Adicionar(new Regiao
                {
                    Nome = item.Nome,
                    Sigla = item.Sigla
                });

                foreach (var itemMicro in regionCleanList)
                {
                    await _microRegionRepository.Adicionar(new MicroRegiao
                    {
                        Nome = itemMicro.Nome,
                        Sigla = itemMicro.Sigla,
                        RegiaoId = region.Id
                    });
                }
            }


            return new MensagemDto("Carga Efetuada com sucesso !");

        }

    }

}


