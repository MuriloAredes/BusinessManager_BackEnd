using BusinessManagement.Domain.Dtos;

namespace BusinessManagement.Application.EmpresaService.Registrar
{
    public interface IRegisterCompanyService
    {
        Task<RegisterCompanyResponse> Register(RegisterCompanyRequest request);
    }
}
