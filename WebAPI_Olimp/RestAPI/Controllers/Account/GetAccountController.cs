using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.IAccounts;
using RestAPI.Authorization;
using Application.Interfaces;
using System.Text.RegularExpressions;

namespace RestAPI.Controllers.Account
{

    [Route("accounts")]
    [ApiController]
    public class GetAccountController : Controller
    {
        private readonly IGetAccountInformation _getUserInformation;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;

        public GetAccountController(IGetAccountInformation getUserInformation, ICheckAuthorization checkAuthorization)
        {
            _getUserInformation = getUserInformation;
            _checkAuthorization = checkAuthorization;
        }
        [HttpGet("{accountId}")]
        public IActionResult GetAll(int accountId) 
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (accountId <= 0) return BadRequest();
            try
            {
                return Ok(Json(_getUserInformation.GetAccount(accountId).Result).Value);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("search")]
        public IActionResult Get(string? firstName, string? lastName, string? email, int from = 0, int size = 10) 
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return Unauthorized();
            }
            catch { }

            if (from < 0 || size <= 0) return BadRequest();
            try
            {
                return Ok(Json(_getUserInformation.SearchAccounts(firstName, lastName, email).Result.Skip(0).Take(size)).Value);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
