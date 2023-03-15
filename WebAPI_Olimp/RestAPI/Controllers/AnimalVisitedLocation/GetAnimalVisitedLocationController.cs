using Application.Interfaces;
using Application.Interfaces.IVisitedLocation;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;

namespace RestAPI.Controllers.AnimalVisitedLocation
{
    [Route("animals")]
    [ApiController]
    public class GetAnimalVisitedLocationController : Controller
    {
        private readonly IGetAnimalVisitedLocation _getAnimalVisitedLocation;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;

        public GetAnimalVisitedLocationController(IGetAnimalVisitedLocation getAnimalVisitedLocation, ICheckAuthorization checkAuthorization)
        {
            _getAnimalVisitedLocation = getAnimalVisitedLocation;
            _checkAuthorization = checkAuthorization;
        }

        [HttpGet("{animalId}/locations")]
        public IActionResult GetAnimalVisitedLocation(long animalId, DateTime startDateTime, DateTime endDateTime, int from = 0, int size = 10) 
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (animalId <= 0 || from < 0 || size <= 0)
            {
                return BadRequest();
            }
            try
            {
                return Ok(Json(_getAnimalVisitedLocation.GetLocations(
                    animalId, startDateTime, endDateTime).Result).Value);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
