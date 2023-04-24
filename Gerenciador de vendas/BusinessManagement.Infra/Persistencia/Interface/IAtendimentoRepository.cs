using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infra.Persistencia.Interface
{
    public  interface IAtendimentoRepository
    {
        Task Adicionar(Atendimento Atendimento);
        Task<bool> Atualizar(Atendimento Atendimento);
        Task<bool> Excluir(Guid Id);
        Task<Atendimento> ObterPorId(Guid Id);
        IEnumerable<Atendimento> GetAll(string Search);
    }
}
