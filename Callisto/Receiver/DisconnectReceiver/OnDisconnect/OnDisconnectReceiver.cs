using Callisto.Database.Models.AccountModel;
using Callisto.Database.Models.CharacterModel;
using Callisto.Database.Models.MapModel;
using Callisto.Receiver.CharacterReceiver.RemoveCharacter;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.DisconnectReceiver.Disconnect
{
    public class OnDisconnectReceiver: IReceiver
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapRepository _mapRepository;

        public OnDisconnectReceiver(IAccountRepository accountRepository, ICharacterRepository characterRepository, IMapRepository mapRepository)
        {
            _accountRepository = accountRepository;
            _characterRepository = characterRepository;
            _mapRepository = mapRepository;
        }

        public async Task Listen(Socket socket, string _)
        {
            if(socket.volatileInformation.characterId != null)
            {
                var character = await _characterRepository.GetCharacter(socket.volatileInformation.characterId);
                var map = await _mapRepository.GetMap(character.MapPosition);
                Callisto.Instance().State.RemoveCharacterFromMap(character.MapPosition, socket.volatileInformation.characterId);
                socket.LeaveAll();
                socket.Broadcast(map.Name, RemoveCharacterAlias.REMOVE_CHARACTER, new RemoveCharacterRequest()
                {
                    characterId = character.Id.ToString()
                });
            }
        }
    }
}
