using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Data;
using BusinessManagement.Infra.Persistencia.Interface;

namespace BusinessManagement.Infra.Persistencia
{
    public class MicroRegionRepository : IMicroRegionRepository
    {

        private readonly DataContext _dataContext;

        public MicroRegionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Adicionar(MicroRegiao microRegiao)
        {
            await _dataContext.MicroRegioes.AddAsync(microRegiao);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<bool> Atualizar(MicroRegiao microRegiao)
        {
            if (microRegiao is not null)
            {
                await _dataContext.MicroRegioes.FindAsync(microRegiao);

                return true;
            }

            return false;
        }

        public async Task<bool> Excluir(Guid Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                await _dataContext.MicroRegioes.FindAsync(Id);

                return true;
            }
            return false;
        }

        public  IEnumerable<MicroRegiao> GetAll()
        {
            var result =  _dataContext.MicroRegioes.AsEnumerable().ToList();

           
            return result;
        }

        public async Task<MicroRegiao> ObterPorId(Guid Id)
        {
            MicroRegiao? result = await _dataContext.MicroRegioes.FindAsync(Id.ToString());
            return result ?? new MicroRegiao();
        }
    }
}
