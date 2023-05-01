using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infra.Persistencia.Interface
{
    public interface IVendedorRepository
    {
        Task<Vendedor> Adicionar(Vendedor Vendedor);
        Task<bool> Atualizar(Vendedor Vendedor);
        Task<bool> Excluir(Guid Id);
        Task<Vendedor> ObterPorId(Guid Id);
        IEnumerable<Vendedor> GetAll(string Search);
    }
}
