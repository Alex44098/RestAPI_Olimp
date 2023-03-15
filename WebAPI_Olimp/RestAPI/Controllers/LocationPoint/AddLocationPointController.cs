using Application.Interfaces;
using Application.Interfaces.ILocationPoint;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;
using RestAPI.Controllers.JsonPropertis;

namespace RestAPI.Controllers.LocationPoint
{
    [Route("locations")]
    [ApiController]
    public class AddLocationPointController : Controller
    {
        private readonly IAddLocationPoint _addLocationPoint;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;
        public AddLocationPointController(IAddLocationPoint addLocationPoint, ICheckAuthorization checkAuthorization)
        {
            _addLocationPoint = addLocationPoint;
            _checkAuthorization = checkAuthorization;
        }
        [HttpPost]
        public IActionResult AddPoint([FromBody] LocationPointJson pointJson)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (pointJson.Latitude < -90 || pointJson.Latitude > 90 ||
                pointJson.Longitude < -180 || pointJson.Longitude > 180)
                return BadRequest();

            return StatusCode(201, Json(_addLocationPoint.AddPoint(
                pointJson.Latitude, pointJson.Longitude).Result).Value);
        }
    }
}
