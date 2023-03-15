using Application.Interfaces;
using Application.Interfaces.IAnimal;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;

namespace RestAPI.Controllers.Animal
{
    [Route("animals")]
    [ApiController]
    public class GetAnimalController : Controller
    {
        private readonly IGetAnimalInformation _getAnimalInformation;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;

        public GetAnimalController(IGetAnimalInformation getAnimalInformation, ICheckAuthorization checkAuthorization)
        {
            _getAnimalInformation = getAnimalInformation;
            _checkAuthorization = checkAuthorization;
        }

        [HttpGet("{animalId}")]
        public IActionResult GetAnimalById(long animalId)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (animalId <= 0) return BadRequest();
            try
            {
                return Ok(Json(_getAnimalInformation.GetAnimal(animalId).Result).Value);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("search")]
        public IActionResult GetAnimalBySearch(
                int? chipperId = null,
                long? chippingLocationId = null,
                string? lifeStatus = null,
                string? gender = null,
                DateTime? startDateTime = null,
                DateTime? endDateTime = null,
                int from = 0,
                int size = 10)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (from < 0 || size <= 0 || chipperId <= 0 || chippingLocationId <= 0 ||
                (lifeStatus != "ALIVE" && lifeStatus != "DEAD") ||
                (gender != "MALE" && gender != "FEMALE" && gender != "OTHER"))
                return BadRequest();

            if (startDateTime == null) startDateTime = DateTime.MinValue;
            if (endDateTime == null) endDateTime = DateTime.MaxValue;

            return Ok(Json(_getAnimalInformation.SearchAnimals(
                startDateTime, endDateTime, chipperId, chippingLocationId, lifeStatus, gender
                ).Result).Value);
        }
    }
}
