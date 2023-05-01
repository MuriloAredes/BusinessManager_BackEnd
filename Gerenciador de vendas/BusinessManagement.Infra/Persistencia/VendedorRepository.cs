using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Data;
using BusinessManagement.Infra.Persistencia.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.Infra.Persistencia
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly DataContext _dataContext;
        public VendedorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Vendedor> Adicionar(Vendedor Vendedor)
        {
            await _dataContext.Vendedores.AddAsync(Vendedor);
            await _dataContext.SaveChangesAsync();
            
           Vendedor result = await _dataContext.Vendedores.FirstAsync(x => x.Email.Equals(Vendedor.Email));
            return result ?? new Vendedor();
        }

        public async Task<bool> Atualizar(Vendedor Vendedor)
        {
            if (Vendedor is not null)
            {
                await _dataContext.Vendedores.FindAsync(Vendedor);

                return true;
            }

            return false;
        }

        public async  Task<bool> Excluir(Guid Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                await _dataContext.Vendedores.FindAsync(Id);

                return true;
            }
            return false;
        }

        public IEnumerable<Vendedor> GetAll(string Search)
        {
            var result = _dataContext.Vendedores.Where(o =>
                                                           !string.IsNullOrEmpty(Search) ||
                                                           o.Nome.Contains(Search) ||
                                                           o.Sobrenome.Contains(Search) ||
                                                           o.Cep.Contains(Search) ||
                                                           o.Complemento.Contains(Search) ||
                                                           o.Email.Contains(Search) ||
                                                           o.Endereco.Contains(Search)

                                                        ).Select(res => res).ToList();
            return result;
        }

        public  async Task<Vendedor> ObterPorId(Guid Id)
        {
            
                Vendedor? result = await _dataContext.Vendedores.FirstOrDefaultAsync(o => o.Id.Equals(Id));
                return result ?? new Vendedor();
            
        }
    }
}
