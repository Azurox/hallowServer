using Callisto.Database.Models;
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
    }
}