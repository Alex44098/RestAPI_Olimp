using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers.JsonPropertis;
using Application.Interfaces.IAccounts;
using Application.Interfaces;
using RestAPI.Authorization;
using Application.Authorization;
using System.Text.RegularExpressions;

namespace RestAPI.Controllers.Account
{
    [Route("registration")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationAccount _registrationAccount;
        private readonly ICheckAuthorization _checkAuthorization;
        private CheckAuth? checkAuth;
        public RegistrationController(IRegistrationAccount account, ICheckAuthorization checkAuthorization)
        {
            _registrationAccount = account;
            _checkAuthorization = checkAuthorization;
        }
        [HttpPost]
        public IActionResult Registration([FromBody] AccountJson accountJson)
        {
            try
            {
                checkAuth = new CheckAuth(Request, _checkAuthorization);
                if (!checkAuth.checkAuth()) return StatusCode(403);
            }
            catch { }

            if (accountJson.FirstName == "" || accountJson.FirstName.Trim() == string.Empty ||
                accountJson.LastName == "" || accountJson.LastName.Trim() == string.Empty ||
                accountJson.Email == "" || accountJson.Email.Trim() == string.Empty ||
                accountJson.Password == "" || accountJson.Password.Trim() == string.Empty ||
                !IsValid(accountJson.Email))
                return BadRequest();

            try
            {
                return StatusCode(201, Json(_registrationAccount.RegAccount(
                accountJson.FirstName, accountJson.LastName, accountJson.Email, accountJson.Password).Result).Value);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
        }
        bool IsValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}