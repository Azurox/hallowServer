using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Database.Models
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDatabaseContext _context;
        public AccountRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public Task<Account> GetAccount(string email)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq(m => m.Email, email);
            return _context
                    .Accounts
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(Account account)
        {
            await _context.Accounts.InsertOneAsync(account);
        }
        public async Task<bool> Update(Account account)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Accounts
                        .ReplaceOneAsync(
                            filter: g => g.Id == account.Id,
                            replacement: account);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string email)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq(m => m.Email, email);
            DeleteResult deleteResult = await _context
                                                .Accounts
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}