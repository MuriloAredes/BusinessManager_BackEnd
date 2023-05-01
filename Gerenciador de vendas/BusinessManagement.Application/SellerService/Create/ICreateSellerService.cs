using BusinessManagement.Domain.Dtos;

namespace BusinessManagement.Application.SellerService.Create
{
    public interface ICreateSellerService
    {
        Task<CreateSellerResponse> Create(CreateSellerRequest request);
    }
}
