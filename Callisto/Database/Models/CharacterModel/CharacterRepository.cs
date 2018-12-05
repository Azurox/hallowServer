using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Database.Models.CharacterModel
{
    public class CharacterRepository: ICharacterRepository
    {
        private readonly IDatabaseContext _context;
        public CharacterRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<Character> GetCharacter(string id)
        {
            FilterDefinition<Character> filter = Builders<Character>.Filter.Eq(c => c.Id, new ObjectId(id));
            return _context
                    .Characters
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public Task<Character> GetCharacter(ObjectId id)
        {
            FilterDefinition<Character> filter = Builders<Character>.Filter.Eq(c => c.Id, id);
            return _context
                    .Characters
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Character character)
        {
            await _context.Characters.InsertOneAsync(character);
        }

        public async Task<bool> CharacterExist(string name)
        {
            FilterDefinition<Character> filter = Builders<Character>.Filter.Eq(m => m.Name, name);
            return await _context
                .Characters
                .Find(filter)
                .FirstOrDefaultAsync() != null;
        }

        public async Task<bool> Update(Character character)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Characters
                        .ReplaceOneAsync(
                            filter: g => g.Id == character.Id,
                            replacement: character);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Character> filter = Builders<Character>.Filter.Eq(c => c.Id, new ObjectId(id));
            DeleteResult deleteResult = await _context
                                                .Characters
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
