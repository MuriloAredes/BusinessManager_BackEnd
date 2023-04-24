using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Data;
using BusinessManagement.Infra.Persistencia.Interface;

namespace BusinessManagement.Infra.Persistencia
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext _dataContext;

        public RegionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Regiao> Adicionar(Regiao regiao)
        {
            await _dataContext.Regioes.AddAsync(regiao);
            await _dataContext.SaveChangesAsync();

            return _dataContext.Regioes.FirstOrDefault(o => o.Sigla.Equals(regiao.Sigla));

        }

        public async Task<bool> Atualizar(Regiao regiao)
        {
            if (regiao is not null)
            {
                await _dataContext.Regioes.FindAsync(regiao);

                return true;
            }

            return false;
        }

        public async Task<bool> Excluir(Guid Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                await _dataContext.Regioes.FindAsync(Id);

                return true;
            }
            return false;
        }

        public IEnumerable<Regiao> GetAll()
        {
            var result = _dataContext.Regioes.AsEnumerable().ToList();
            return result;
        }

        public async Task<Regiao> ObterPorId(Guid Id)
        {
            Regiao? result = await _dataContext.Regioes.FindAsync(Id.ToString());
            return result ?? new Regiao();
        }
    }
}
