using Callisto.Database.Models.AccountModel;
using Callisto.Database.Models.CharacterModel;
using Callisto.Receiver.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.CreateCharacter
{
    public class CreateCharacterReceiver : IReceiver
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;

        public CreateCharacterReceiver(IAccountRepository accountRepository, ICharacterRepository characterRepository)
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

            if (!await _characterRepository.CharacterExist(request.name))
            {
                var character = new Character()
                {
                    Name = request.name
                };
                await _characterRepository.Create(character);
                var account = await _accountRepository.GetAccount(socket.volatileInformation.accountId);
                account.Characters.Add(character.Id);
                await _accountRepository.Update(account);
                socket.volatileInformation.characterId = character.Id.ToString();

            }
            else
            {
                socket.Emit(CreateCharacterRequestAlias.NAME_ALREADY_TAKEN);
            }
        }
    }
}
