using Application.ViewModels;

namespace Application.Interfaces.ILocationPoint
{
    public interface IGetLocationPoint
    {
        public Task<LocationPointViewmodel> GetLocationPoint(long id);
    }
}
