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
            _regionInteractor= regionInteractor;
            _regionRepository= regionRepository;
            _microRegionRepository= microRegionRepository;
        }
        public async Task<MensagemDto> RegisterRegion()
        {
            var resultRegionsInteractor = await _regionInteractor.GetAllRegion();
            var regionDb = _regionRepository.GetAll();
            var microRegion = _microRegionRepository.GetAll();

            var microRegions = resultRegionsInteractor.Select(o => new MicroRegiao { Id = o.Id, Nome = o.Nome, Sigla = o.Sigla });
            var regions = regionDb.Select(o => new Regiao { Id = o.Id, Nome = o.Nome, Sigla = o.Sigla });

            bool microRegionIsValid = microRegion.SequenceEqual(microRegions);
            bool regionIsValid = regionDb.SequenceEqual(regions);

            if (!regionIsValid && !microRegionIsValid)
            {

              foreach(var item in resultRegionsInteractor) 
                {
                   var regiao =  await _regionRepository.Adicionar(new Regiao
                    {
                        Nome = item.Region!.Nome,
                        Sigla = item.Region.Sigla,
                    });

                   await _microRegionRepository.Adicionar(new MicroRegiao 
                    { 
                        Id = item.Id,
                        Nome = item.Nome,
                        Sigla =item.Sigla,
                        RegiaoId = regiao.Id
                        
                    });
                }

            }

            return new MensagemDto("Carga Efetuada com sucesso !");

        }
    }
}
