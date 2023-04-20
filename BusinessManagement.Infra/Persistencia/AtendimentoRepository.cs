using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Data;
using BusinessManagement.Infra.Persistencia.Interface;

namespace BusinessManagement.Infra.Persistencia
{
    public class AtendimentoRepository : IAtendimentoRepository
    {

        private readonly DataContext _dataContext;
        public AtendimentoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Adicionar(Atendimento Atendimento)
        {
            await _dataContext.Atendimentos.AddAsync(Atendimento);
   
        }

        public async Task<bool> Atualizar(Atendimento atendimento)
        {
            if (atendimento is not null)
            {
                await _dataContext.Atendimentos.FindAsync(atendimento);

                return true;
            }

            return false;
        }

        public async Task<bool> Excluir(Guid Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                await _dataContext.Atendimentos.FindAsync(Id);

                return true;
            }
            return false;
        }

        public IEnumerable<Atendimento> GetAll(string Search)
        {
            var result = _dataContext.Atendimentos.Where(o =>
                                                             !string.IsNullOrEmpty(Search) ||
                                                             o.Titulo.Equals(Search))
                                                  
                                                  .Select(res => res).ToList();
            return result;
        }

        public async Task<Atendimento> ObterPorId(Guid Id)
        {
            Atendimento? result = await _dataContext.Atendimentos.FindAsync(Id.ToString());
            return result ?? new Atendimento();
        }
    }
}
