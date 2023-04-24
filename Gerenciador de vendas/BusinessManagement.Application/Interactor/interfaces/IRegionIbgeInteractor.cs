using BusinessManagement.Domain.Dtos;

namespace BusinessManagement.Application.Interactor.interfaces
{
    public interface IRegionIbgeInteractor
    {
        public Task<List<MicroRegiaoDto>> GetAllRegion();
    }
}
