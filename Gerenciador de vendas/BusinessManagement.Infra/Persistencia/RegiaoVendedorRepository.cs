using BusinessManagement.Domain.Dtos;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Data;
using BusinessManagement.Infra.Persistencia.Interface;

namespace BusinessManagement.Infra.Persistencia
{
    public class RegiaoVendedorRepository : IRegiaoVendedorRepository
    {
        private readonly DataContext _dataContext;

        public RegiaoVendedorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       
        public async Task<RegiaoVendedor> Adicionar(RegiaoVendedor regiaoVendedor)
        {
            await _dataContext.RegiaoVendedores.AddAsync(regiaoVendedor);
            await _dataContext.SaveChangesAsync();

            var result = _dataContext.RegiaoVendedores.FirstOrDefault(o => o.VendedorId.Equals(regiaoVendedor.VendedorId));

            return result ?? new RegiaoVendedor();
        }

        public async  Task<bool> Atualizar(RegiaoVendedor regiaoVendedor)
        {
            if (regiaoVendedor is not null)
            {
                await _dataContext.RegiaoVendedores.FindAsync(regiaoVendedor);

                return true;
            }

            return false;
        }

        public async Task<bool> Excluir(Guid Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                await _dataContext.RegiaoVendedores.FindAsync(Id);

                return true;
            }
            return false;
        }

        public IEnumerable<RegiaoVendedor> GetAll()
        {
            var result = _dataContext.RegiaoVendedores.AsEnumerable().ToList();
            return result;
        }

        public async Task<RegiaoVendedor> ObterPorId(string Id)
        {
            RegiaoVendedor? result = await _dataContext.RegiaoVendedores.FindAsync(Id.ToString());
            return result ?? new RegiaoVendedor();
        }
    }
}
