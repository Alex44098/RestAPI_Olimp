using Application.ViewModels;

namespace Application.Interfaces.ILocationPoint
{
    public interface IAddLocationPoint
    {
        public Task<LocationPointViewmodel> AddPoint
           (double latitude, double longitude);
    }
}
