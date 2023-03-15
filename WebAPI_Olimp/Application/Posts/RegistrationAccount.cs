using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IAccounts;
using Application.ViewModels;
using AutoMapper;
using Models.Entitis;

namespace Application.Posts
{
    public class RegistrationAccount : IRegistrationAccount
    {
        private readonly IMainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        public RegistrationAccount(IMainDbContext mainDbContext, IMapper mapper) 
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
        }
        public async Task<AccountViewmodel> RegAccount
            (string firstName, string lastName, string email, string password)
        {
            var acc = _mainDbContext.Accounts.Where(usr => usr.email == email).FirstOrDefault();
            if (acc != null) throw new Exception("email");
            Account account = new Account
            {
                id = new int(),
                firstName = firstName,
                lastName = lastName,
                email = email,
                password = password
            };
            await _mainDbContext.Accounts.AddAsync(account);
            await _mainDbContext.SaveChangesAsync();

            return _mapper.Map<AccountViewmodel>(account);
        }
    }
}