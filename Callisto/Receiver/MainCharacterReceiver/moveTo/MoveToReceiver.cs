using Callisto.Database.Models.CharacterModel;
using Callisto.Database.Models.Common;
using Callisto.Database.Models.MapModel;
using Callisto.Receiver.CharacterReceiver.MoveCharacter;
using Callisto.Receiver.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MainCharacterReceiver.moveTo
{
    public class MoveToReceiver : IReceiver
    {
        private readonly IMapRepository _mapRepository;
        private readonly ICharacterRepository _characterRepository;

        public MoveToReceiver(IMapRepository mapRepository, ICharacterRepository characterRepository)
        {
            _mapRepository = mapRepository;
            _characterRepository = characterRepository;
        }

        internal class Request
        {
            public List<Position> path;
        }

        public async Task Listen(Socket socket, string data)
        {
            var request = JsonConvert.DeserializeObject<Request>(data);
            var character = await _characterRepository.GetCharacter(socket.volatileInformation.characterId);
            var map = await _mapRepository.GetMap(character.MapPosition);
            // [HORS MVP] TODO : Check if path is valid.

            socket.Emit(MoveToRequestAlias.LEGAL_MOVEMENT);
            socket.Broadcast(map.Name, MoveCharacterAlias.MOVE_CHARACTER, new MoveCharacterRequest()
            {
                characterId = character.Id.ToString(),
                startPosition = character.Position,
                path = request.path
            });


        }
    }
}
