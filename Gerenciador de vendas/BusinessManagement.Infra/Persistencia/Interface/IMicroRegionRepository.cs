using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infra.Persistencia.Interface
{
    public interface IMicroRegionRepository
    {
        Task Adicionar(MicroRegiao microRegiao);
        Task<bool> Atualizar(MicroRegiao microRegiao);
        Task<bool> Excluir(Guid Id);
        Task<MicroRegiao> ObterPorEstado(string Id);
        IEnumerable<MicroRegiao> GetAll();
    }
}
