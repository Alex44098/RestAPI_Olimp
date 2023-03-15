using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;
using Models.Entitis;
using Application.ViewModels;
using Application.Interfaces.IAccounts;

namespace Application.Gets.GetAccount
{
    public class GetAccountInformation : IGetAccountInformation
    {
        private readonly IMainDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAccountInformation(IMainDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        //Получение информации через об аккаунте id
        public async Task<AccountViewmodel> GetAccount(int id/*, CancellationToken cancellationToken*/)
        {
            var user = await _dbContext.Accounts.Where(usr => usr.id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new NotFoundException(nameof(Account), id.ToString());
            }

            return _mapper.Map<AccountViewmodel>(user);
        }
        //получение информации об аккаунте через имя, фамилию или эл. почту
        public async Task<List<AccountViewmodel>> SearchAccounts(string? firstName, string? lastName, string? email)
        {
            //для поиска аккаунтов применяется фильтрация параметров
            //параметры, равные null не участвуют в поиске 
            var account = await _dbContext.Accounts
                .Where(usr => firstName != null ? usr.firstName == firstName : true) //тернарные операторы, внимательнее (это я для себя)
                .Where(usr => lastName != null ? usr.lastName == lastName : true)
                .Where(usr => email != null ? usr.email == email : true).ToListAsync();
            if (account.Count == 0)
            {
                throw new NotFoundException(nameof(Account), firstName + " " + lastName);
            }

            return _mapper.Map<List<AccountViewmodel>>(account);
        }

    }
}
