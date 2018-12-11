using Callisto.Database.Models.AccountModel;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Database.Models.CharacterModel;
using Newtonsoft.Json;

namespace Callisto.Receiver.AccountReceiver.SelectCharacter
{
    public class SelectCharacterReceiver: IReceiver
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;

        public SelectCharacterReceiver(IAccountRepository accountRepository, ICharacterRepository characterRepository)
        {
            _accountRepository = accountRepository;
            _characterRepository = characterRepository;
        }

        internal class Request
        {
            public string name;
        }

        public async Task Listen(Socket socket, string data)
        {
            var request = JsonConvert.DeserializeObject<Request>(data);
            var account = await _accountRepository.GetAccount(socket.volatileInformation.accountId);
            Character selectedChar = null;
            foreach (var characterId in account.Characters)
            {
                var character = await _characterRepository.GetCharacter(characterId);
                if (character.Name != request.name) continue;
                selectedChar = character;
                break;
            }

            if (selectedChar != null)
            {
                socket.volatileInformation.characterId = selectedChar.Id.ToString();
                Callisto.Instance().State.AddCharacterToMap(selectedChar.MapPosition, selectedChar);
                socket.Emit(SelectCharacterRequestAlias.GO_TO_WORLD);
            }

        }
    }
}
