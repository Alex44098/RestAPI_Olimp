using Application.Interfaces;
using Application.Interfaces.IAnimal;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Authorization;
using RestAPI.Controllers.JsonPropertis;

namespace RestAPI.Controllers.Animal
{
    [Route("animals")]
    [ApiController]
    public class AddAnimalController : Controller
    {
        private readonly IAddAnimalInformation _animalInformation;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;

        public AddAnimalController(IAddAnimalInformation animalInformation, ICheckAuthorization checkAuthorization)
        {
            _animalInformation = animalInformation;
            _checkAuthorization = checkAuthorization;
        }

        [HttpPost]
        public IActionResult AddAnim([FromBody] AnimalJson animalJson)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }



            return StatusCode(201, Json(_animalInformation.AddAnimal(
                animalJson.AnimalTypes,
                animalJson.Weight,
                animalJson.Lenght,
                animalJson.Height,
                animalJson.Gender,
                animalJson.ChipperId,
                animalJson.ChippingLocationId).Result).Value);
        }
    }
}
