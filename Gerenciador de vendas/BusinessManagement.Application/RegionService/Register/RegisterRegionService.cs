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


            List<Regiao> regionListFilter = new List<Regiao>();
            List<MicroRegiao> microRegionListFilter = new List<MicroRegiao>();

            foreach (var microRegion in resultRegionsInteractor)
            {
                string siglaRegion = microRegion.Region!.Sigla;
                var hasRegion = regionListFilter.FirstOrDefault(o => o.Sigla.Equals(siglaRegion));
                var hasRegionContext = regionDb.FirstOrDefault(o => o.Sigla.Equals(siglaRegion));

                if (hasRegion is null  &&  hasRegionContext is null) 
                {
                    regionListFilter.Add(new Regiao { Nome = microRegion.Region.Nome, Sigla = microRegion.Region.Sigla});
                }

                var siglaMicroRegion = microRegion.Sigla!;
                var hasMicroReg = microRegionListFilter.FirstOrDefault(o => o.Sigla.Equals(siglaMicroRegion));
                var hasMicroRegionContext = microRegionDb.FirstOrDefault(o => o.Sigla.Equals(siglaMicroRegion));

                if(hasMicroReg is null && hasMicroRegionContext is null)
                {
                    microRegionListFilter.Add(new MicroRegiao { Nome = microRegion.Nome, Sigla = microRegion.Sigla });
                }

            }

            foreach (var item in regionListFilter)
            {
                var region = await _regionRepository.Adicionar(new Regiao
                {
                    Nome = item.Nome,
                    Sigla = item.Sigla
                });

                foreach (var itemMicro in microRegionListFilter)
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


