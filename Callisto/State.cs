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
        private Dictionary<Position, Dictionary<string, Character>> charactersByMap = new Dictionary<Position, Dictionary<string, Character>>();


        public HashSet<Character> GetCharactersOnMap(Position position)
        {
            if (charactersByMap.ContainsKey(position))
            {
                return new HashSet<Character>(charactersByMap[position].Values);
            } else
            {
                return new HashSet<Character>();
            }
        }

        public void AddCharacterToMap(Position position, Character character)
        {
            if (charactersByMap.ContainsKey(position))
            {
                charactersByMap[position].Add(character.Id.ToString(), character);
            }
            else
            {
                charactersByMap[position] = new Dictionary<string, Character>() { { character.Id.ToString(), character } };
            }
        }

        public void MoveCharacterFromMap(Position oldPosition, Position newPosition, Character character)
        {
            MoveCharacterFromMap(oldPosition, newPosition, character.Id.ToString());
        }

        public void MoveCharacterFromMap(Position oldPosition, Position newPosition, string characterId)
        {
            if (charactersByMap.ContainsKey(oldPosition) && charactersByMap[oldPosition].ContainsKey(characterId))
            {
                var character = charactersByMap[oldPosition][characterId];
                charactersByMap[oldPosition].Remove(characterId);
                AddCharacterToMap(newPosition, character);
            }
            else
            {
                throw new Exception($"Character is not on the map {oldPosition}, unable to move it to {newPosition}");
            }
        }
    }
}
