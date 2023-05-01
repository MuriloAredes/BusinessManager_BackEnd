using BusinessManagement.Domain.Dtos;
using BusinessManagement.Infra.Persistencia.Interface;

namespace BusinessManagement.Application.EmpresaService.Registrar
{
    public class RegistrarCompanyService : IRegisterCompanyService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public RegistrarCompanyService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository= empresaRepository;
        }
        public Task<RegisterCompanyResponse> Register(RegisterCompanyRequest request)
        {
            
            throw new NotImplementedException();
        }
    }
}
