
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Callisto.Database.Models.AccountModel
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDatabaseContext _context;
        public AccountRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public Task<Account> GetAccount(string email, string password)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq(m => m.Email, email) & Builders<Account>.Filter.Eq(m => m.Password, password);
            return _context
                    .Accounts
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> AccountExist(string email)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq(m => m.Email, email);
            return await _context
                .Accounts
                .Find(filter)
                .FirstOrDefaultAsync() != null;
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