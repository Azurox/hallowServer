using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Database.Models.AccountModel
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(string email, string password);
        Task Create(Account account);
        Task<bool> AccountExist(string email);
        Task<bool> Update(Account account);
        Task<bool> Delete(string email);
    }
}