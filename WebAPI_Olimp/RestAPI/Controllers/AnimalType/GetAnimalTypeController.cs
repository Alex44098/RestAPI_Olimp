using Application.Interfaces;
using Application.Interfaces.IAnimalType;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;

namespace RestAPI.Controllers.AnimalType
{
    [Route("animals/types")]
    [ApiController]
    public class GetAnimalTypeController : Controller
    {
        private readonly IGetAnimalType _getAnimalType;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;

        public GetAnimalTypeController(IGetAnimalType getAnimalType, ICheckAuthorization checkAuthorization)
        {
            _getAnimalType = getAnimalType;
            _checkAuthorization = checkAuthorization;
        }

        [HttpGet("{typeId}")]
        public IActionResult GetAnimType(long typeId)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (typeId <= 0) return BadRequest();

            try
            {
                return Ok(Json(_getAnimalType.GetAnimalType(typeId).Result).Value);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
