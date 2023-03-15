using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;
using Models.Entitis;
using Application.ViewModels;
using Application.Interfaces.ILocationPoint;

namespace Application.Gets.GetLocationPoint
{
    public class GetLocationPointInformation : IGetLocationPoint
    {
        private readonly IMainDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetLocationPointInformation(IMainDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<LocationPointViewmodel> GetLocationPoint(long id)
        {
            var locPoint = await _dbContext.LocationPoints.Where(lp => lp.id == id).FirstOrDefaultAsync();
            if (locPoint == null)
            {
                throw new NotFoundException(nameof(LocationPoint), id.ToString());
            }

            return _mapper.Map<LocationPointViewmodel>(locPoint);
        }
    }
}
