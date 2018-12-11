using Callisto.Database.Models.AccountModel;
using Callisto.Database.Models.CharacterModel;
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

        public OnDisconnectReceiver(IAccountRepository accountRepository, ICharacterRepository characterRepository)
        {
            _accountRepository = accountRepository;
            _characterRepository = characterRepository;
        }

        public async Task Listen(Socket socket, string _)
        {
            if(socket.volatileInformation.characterId != null)
            {
                var character = await _characterRepository.GetCharacter(socket.volatileInformation.characterId);
                Callisto.Instance().State.RemoveCharacterFromMap(character.MapPosition, socket.volatileInformation.characterId);
            }
        }
    }
}
