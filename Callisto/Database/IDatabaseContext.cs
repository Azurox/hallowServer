using Callisto.Database.Models;
using Callisto.Database.Models.AccountModel;
using Callisto.Database.Models.CharacterModel;
using Callisto.Database.Models.MapModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Database
{
    public interface IDatabaseContext
    {
        IMongoCollection<Account> Accounts { get; }
        IMongoCollection<Character> Characters { get; }
        IMongoCollection<Map> Maps { get; }
    }
}