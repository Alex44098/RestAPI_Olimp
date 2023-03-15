using Application.Interfaces;
using Application.Interfaces.IVisitedLocation;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;

namespace RestAPI.Controllers.AnimalVisitedLocation
{
    [Route("animals")]
    [ApiController]
    public class AddAnimalVisitedLocationController : Controller
    {
        private readonly IAddAnimalVisitedLocation addAnimalVisitedLocation;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;

        public AddAnimalVisitedLocationController(IAddAnimalVisitedLocation addAnimalVisitedLocation, ICheckAuthorization checkAuthorization)
        {
            this.addAnimalVisitedLocation = addAnimalVisitedLocation;
            _checkAuthorization = checkAuthorization;
        }

        [HttpPost("{animalId}/locations/{pointId}")]
        public IActionResult AddAnimalVisitedLocation(long animalId, long pointId)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (animalId <= 0 || pointId <= 0) 
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    return StatusCode(201, Json(addAnimalVisitedLocation.AddVisitedLocation(animalId, pointId).Result).Value);
                }
                catch (Exception ex) 
                {
                    if (ex.InnerException.Message == "Request is invalid") return BadRequest();
                    else return NotFound();
                }
            }
        }
    }
}
