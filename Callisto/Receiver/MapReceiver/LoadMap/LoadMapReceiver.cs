using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Database.Models.CharacterModel;
using Callisto.Database.Models.Common;
using Callisto.Database.Models.MapModel;
using Callisto.Receiver.CharacterReceiver.SpawnCharacter;
using Callisto.Receiver.Common;

namespace Callisto.Receiver.MapReceiver.LoadMap
{
    public class LoadMapReceiver: IReceiver
    {
        private readonly IMapRepository _mapRepository;
        private readonly ICharacterRepository _characterRepository;

        public LoadMapReceiver(IMapRepository mapRepository, ICharacterRepository characterRepository)
        {
            _mapRepository = mapRepository;
            _characterRepository = characterRepository;
        }


        public async Task Listen(Socket socket, string data)
        {
            var character = await _characterRepository.GetCharacter(socket.volatileInformation.characterId);
            var map = await _mapRepository.GetMap(character.MapPosition);
            if(map != null)
            {
                socket.Emit(LoadMapRequestAlias.LOAD_MAP, new LoadMapRequest()
                {
                    mapName = map.Name,
                    position = map.Position
                });
                socket.Join(map.Name);
                socket.Broadcast(map.Name, SpawnCharacterAlias.SPAWN_CHARACTER, new SpawnCharacterRequest()
                {
                    character = character
                });

            }
            else
            {
                await _mapRepository.CreateAsync(new Map()
                {
                    Name = "0-0",
                    Position = new Position() { X = 0, Y = 0 }
                });
                Console.WriteLine("no map found, created one");
            }
        }
    }
}
