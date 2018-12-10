using Callisto.Database.Models.CharacterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Database.Models.Common;
using Character = Callisto.Database.Models.CharacterModel.Character;

namespace Callisto
{
    public class State
    {
        private Dictionary<Position, HashSet<Character>> charactersByMap = new Dictionary<Position, HashSet<Character>>();


        public HashSet<Character> GetCharactersOnMap(Position position)
        {
            return charactersByMap.ContainsKey(position) ? charactersByMap[position] : new HashSet<Character>();
        }

        public void AddCharacterToMap(Position position, Character character)
        {
            if (charactersByMap.ContainsKey(position))
            {
                charactersByMap[position].Add(character);
            }
            else
            {
                charactersByMap[position] = new HashSet<Character>{ character };
            }
        }

        public void MoveCharacterFromMap(Position oldPosition, Position newPosition, Character character)
        {
            if (charactersByMap.ContainsKey(oldPosition))
            {
                charactersByMap[oldPosition].Remove(character);
                AddCharacterToMap(newPosition, character);
            }
            else
            {
                throw new Exception($"Character is not on the map {oldPosition}, unable to move it to {newPosition}");
            }
        }

        public void MoveCharacterFromMap(Position oldPosition, Position newPosition, string characterId)
        {
            if (charactersByMap.ContainsKey(oldPosition))
            {
                // var character = charactersByMap[oldPosition].
            }
            else
            {
                throw new Exception($"Character is not on the map {oldPosition}, unable to move it to {newPosition}");
            }
        }
    }
}
