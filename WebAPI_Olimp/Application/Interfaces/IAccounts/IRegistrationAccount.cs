using Application.ViewModels;

namespace Application.Interfaces.IAccounts
{
    public interface IRegistrationAccount
    {
        public Task<AccountViewmodel> RegAccount
            (string firstName, string lastName, string email, string password);
    }
}
