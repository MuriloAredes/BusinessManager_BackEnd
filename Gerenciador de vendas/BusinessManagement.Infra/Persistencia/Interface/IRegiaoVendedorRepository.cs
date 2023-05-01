using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infra.Persistencia.Interface
{
    public interface IRegiaoVendedorRepository
    {
        Task<RegiaoVendedor> Adicionar(RegiaoVendedor regiaoVendedor);
        Task<bool> Atualizar(RegiaoVendedor regiaoVendedor);
        Task<bool> Excluir(Guid Id);
        Task<RegiaoVendedor> ObterPorId(string Id);
        IEnumerable<RegiaoVendedor> GetAll();
    }
}
