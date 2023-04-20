using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infra.Persistencia.Interface
{
    public interface IRegionRepository
    {
        Task<Regiao> Adicionar(Regiao regiao);
        Task<bool> Atualizar(Regiao regiao);
        Task<bool> Excluir(Guid Id);
        Task<Regiao> ObterPorId(Guid Id);
        IEnumerable<Regiao> GetAll();
    }
}
