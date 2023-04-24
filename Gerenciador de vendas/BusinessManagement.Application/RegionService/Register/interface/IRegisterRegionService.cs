using BusinessManagement.Domain.Dtos;

namespace BusinessManagement.Application.RegionService.Register
{
    public interface IRegisterRegionService
    {
        Task<MensagemDto> RegisterRegion();
    }
}
