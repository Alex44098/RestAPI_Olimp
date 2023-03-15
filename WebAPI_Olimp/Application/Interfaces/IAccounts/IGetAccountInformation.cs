using Application.ViewModels;

namespace Application.Interfaces.IAccounts
{
    public interface IGetAccountInformation
    {
        public Task<AccountViewmodel> GetAccount(int id/*, CancellationToken cancellationToken*/);
        public Task<List<AccountViewmodel>> SearchAccounts(string? firstName, string? lastName, string? email);
    }
}
