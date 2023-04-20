using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Infra.Persistencia.Interface
{
    public interface IEmpresaRepository
    {
        Task<Empresa> Adicionar(Empresa Empresa);
        Task<bool> Atualizar(Empresa Empresa);
        Task<bool> Excluir(Guid Id);
        Task<Empresa> ObterPorId(Guid Id);
        IEnumerable<Empresa> GetAll(string Search);

    }
}
