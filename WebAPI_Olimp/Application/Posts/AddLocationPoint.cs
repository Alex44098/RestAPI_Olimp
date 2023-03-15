using Application.Interfaces;
using Application.Interfaces.ILocationPoint;
using Application.ViewModels;
using AutoMapper;
using Models.Entitis;

namespace Application.Posts
{
    public class AddLocationPoint : IAddLocationPoint
    {
        private readonly IMainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        public AddLocationPoint(IMainDbContext mainDbContext, IMapper mapper)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }
        public async Task<LocationPointViewmodel> AddPoint
            (double latitude, double longitude)
        {
            LocationPoint point = new LocationPoint
            {
                id = new int(),
                latitude = latitude,
                longitude = longitude
            };
            await _mainDbContext.LocationPoints.AddAsync(point);
            await _mainDbContext.SaveChangesAsync();

            return _mapper.Map<LocationPointViewmodel>(point);
        }
    }
}
