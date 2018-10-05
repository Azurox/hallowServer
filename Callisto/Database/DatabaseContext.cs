using Callisto.Database.Models;
using Callisto.Database.Models.AccountModel;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Database
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _db;
        public DatabaseContext(IOptions<DatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Account> Accounts => _db.GetCollection<Account>("Account");
    }
}