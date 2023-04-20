using BusinessManagement.Domain.Dtos;

namespace BusinessManagement.Application.Interactor.interfaces
{
    public interface ISearchByZipCode
    {
        Task<EnderecoDto> Search(string code);
    }
}
