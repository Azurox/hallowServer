using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Database.Models
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(string email);
        Task Create(Account account);
        Task<bool> Update(Account account);
        Task<bool> Delete(string email);
    }
}