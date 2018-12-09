using Callisto.Database.Models.Common;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Database.Models.MapModel
{
    public interface IMapRepository
    {
        Task<Map> GetMap(string id);
        Task<Map> GetMap(ObjectId id);
        Task<Map> GetMap(Position position);
        Task CreateAsync(Map map);
        Task<bool> UpdateAsync(Map map);
        // Task<bool> Delete(string id);
    }
}
