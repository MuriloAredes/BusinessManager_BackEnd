using BusinessManagement.Domain.Entities;
using BusinessManagement.Infra.Data;
using BusinessManagement.Infra.Persistencia.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.Infra.Persistencia
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DataContext _dataContext;
        public EmpresaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Empresa> Adicionar(Empresa empresa)
        {           
            await _dataContext.Empresas.AddAsync(empresa);

            Empresa result = await _dataContext.Empresas.FirstAsync(x => x.Cnpj.Equals(empresa.Cnpj));
            return result;
        }

        public async Task<bool> Atualizar(Empresa Empresa)
        {
            if (Empresa is not null)
            {
                 await _dataContext.Empresas.FindAsync(Empresa);

                return true;
            }

            return false;
        }

        public async Task<bool> Excluir(Guid Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                 await _dataContext.Empresas.FindAsync(Id);

                return true;
            }
            return false;
        }

        public IEnumerable<Empresa> GetAll(string Search)
        {
            var result = _dataContext.Empresas.Where(o =>
                                                         !string.IsNullOrEmpty(Search) ||
                                                         o.NomeSocial.Contains(Search) ||
                                                         o.Situacao.Contains(Search) ||
                                                         o.Estado.Contains(Search) ||
                                                         o.Cnpj.Contains(Search) ||
                                                         o.Desciçao.Contains(Search)

                                                      ).Select(res => res).ToList();
            return result;
        }

        public async Task<Empresa> ObterPorId(Guid Id)
        {
            Empresa? result = await _dataContext.Empresas.FindAsync(Id.ToString());
            return result?? new Empresa();
        }
    }
}
