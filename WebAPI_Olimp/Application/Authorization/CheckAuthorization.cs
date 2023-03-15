using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Authorization
{
    public class CheckAuthorization : ICheckAuthorization
    {
        private readonly IMainDbContext _mainDbContext;

        public CheckAuthorization(IMainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<bool> Check(string login, string password)
        {
            var account = await _mainDbContext.Accounts
                .Where(usr => usr.email == login)
                .Where(usr => usr.password == password).FirstOrDefaultAsync();
            if (account == null)
            {
                return false;
            }
            return true;
        }
    }
}