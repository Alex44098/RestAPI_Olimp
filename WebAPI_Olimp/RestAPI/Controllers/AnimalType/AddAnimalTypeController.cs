using Application.Interfaces;
using Application.Interfaces.IAnimalType;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;
using RestAPI.Controllers.JsonPropertis;

namespace RestAPI.Controllers.AnimalType
{
    [Route("animals/types")]
    [ApiController]
    public class AddAnimalTypeController : Controller
    {
        private readonly IAddAnimalType _addAnimalType;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;
        public AddAnimalTypeController(IAddAnimalType addAnimalType, ICheckAuthorization checkAuthorization)
        {
            _addAnimalType = addAnimalType;
            _checkAuthorization = checkAuthorization;
        }
        [HttpPost]
        public IActionResult AddAType([FromBody] AnimalTypeJson animTypetJson)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (animTypetJson.Type.Trim() == string.Empty) return BadRequest();

            return StatusCode(201, Json(_addAnimalType.AddAnimType(animTypetJson.Type).Result).Value);
        }
    }
}
