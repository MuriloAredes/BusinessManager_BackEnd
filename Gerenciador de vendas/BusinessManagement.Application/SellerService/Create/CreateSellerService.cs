using BusinessManagement.Application.Interactor.interfaces;
using BusinessManagement.Domain.Dtos;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Persistencia.Interface;

namespace BusinessManagement.Application.SellerService.Create
{
    public class CreateSellerService : ICreateSellerService
    {
        private readonly ISearchByZipCode _searchByZipCode;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IMicroRegionRepository _microRegionRepository;
        private readonly IRegiaoVendedorRepository _regionVendedorRepository;

        public CreateSellerService(ISearchByZipCode searchByZipCode, 
                                   IVendedorRepository vendedorRepository,
                                   IMicroRegionRepository microRegionRepository,
                                   IRegiaoVendedorRepository regiaoVendedorRepository)
        {
            _searchByZipCode= searchByZipCode; 
            _vendedorRepository= vendedorRepository;
            _microRegionRepository= microRegionRepository;
            _regionVendedorRepository = regiaoVendedorRepository;

        }
        public async Task<CreateSellerResponse> Create(CreateSellerRequest request)
        {
            var enderecoInteractor = await _searchByZipCode.Search(request.Cep);

            var microRegion = await _microRegionRepository.ObterPorEstado(enderecoInteractor.EstadoUf);


            var seller = await _vendedorRepository.Adicionar(new Vendedor 
            {
                Nome = request.Nome,
                Sobrenome= request.Sobrenome,
                Email= request.Email,
                Cep= request.Cep,
                Endereco = request.Endereco,
                Numero= request.Numero,
                Complemento= request.Complemento,             
            });

            await _regionVendedorRepository.Adicionar(new RegiaoVendedor 
            {
                RegionId = microRegion.RegiaoId ?? 0,
                VendedorId = seller.Id,
                Status = true,
                
            });
            

            return new CreateSellerResponse("Vendedor registrado com sucesso");
        }
    }
}
