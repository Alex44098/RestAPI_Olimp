using Application.Interfaces;
using Application.Interfaces.ILocationPoint;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;

namespace RestAPI.Controllers.LocationPoint
{
    [Route("locations")]
    [ApiController]
    public class GetLocationPointController : Controller
    {
        private readonly IGetLocationPoint _getLocationPoint;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;
        public GetLocationPointController(IGetLocationPoint getLocationPoint, ICheckAuthorization checkAuthorization)
        {
            _getLocationPoint = getLocationPoint;
            _checkAuthorization = checkAuthorization;
        }
        [HttpGet("{pointId}")]
        public IActionResult GetPoint(long pointId)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (pointId <= 0) return BadRequest();
            try
            {
                return Ok(Json(_getLocationPoint.GetLocationPoint(pointId).Result).Value);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
