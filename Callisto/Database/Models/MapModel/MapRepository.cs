using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Database.Models.Common;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Callisto.Database.Models.MapModel
{
    public class MapRepository : IMapRepository
    {

        private readonly IDatabaseContext _context;
        public MapRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Map map)
        {
            await _context.Maps.InsertOneAsync(map);
        }

        public Task<Map> GetMap(string id)
        {
            FilterDefinition<Map> filter = Builders<Map>.Filter.Eq(c => c.Id, new ObjectId(id));
            return _context
                    .Maps
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<Map> GetMap(ObjectId id)
        {
            FilterDefinition<Map> filter = Builders<Map>.Filter.Eq(c => c.Id, id);
            return _context
                    .Maps
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<Map> GetMap(Position position)
        {
            FilterDefinition<Map> filter = Builders<Map>.Filter.Eq(c => c.Position, position);
            return _context
                    .Maps
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Map map)
        {
            ReplaceOneResult updateResult =
               await _context
                       .Maps
                       .ReplaceOneAsync(
                           filter: g => g.Id == map.Id,
                           replacement: map);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
