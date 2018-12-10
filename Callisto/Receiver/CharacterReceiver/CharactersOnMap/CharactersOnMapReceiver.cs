using Callisto.Database.Models.CharacterModel;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.CharacterReceiver.CharactersOnMap
{
    public class CharactersOnMapReceiver: IReceiver
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersOnMapReceiver(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }


        public async Task Listen(Socket socket, string data)
        {
            var character = await _characterRepository.GetCharacter(socket.volatileInformation.characterId);
            var characters = Callisto.Instance().State.GetCharactersOnMap(character.MapPosition);
            characters.RemoveWhere(c => c.Id == character.Id);
            socket.Emit(CharactersOnMapAlias.CHARACTERS_ON_MAP, new CharactersOnMapRequest()
            {
                characters = characters
            });
        }
    }
}
