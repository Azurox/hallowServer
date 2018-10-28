using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Database.Models.CharacterModel
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacter(string id);
        Task Create(Character character);
        Task<bool> Update(Character character);
        Task<bool> Delete(string id);
    }
}
