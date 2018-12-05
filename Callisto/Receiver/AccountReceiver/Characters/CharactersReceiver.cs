using Callisto.Database.Models.AccountModel;
using Callisto.Database.Models.CharacterModel;
using Callisto.Receiver.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.Characters
{
    public class CharactersReceiver: IReceiver
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;

        public CharactersReceiver(IAccountRepository accountRepository, ICharacterRepository characterRepository)
        {
            _accountRepository = accountRepository;
            _characterRepository = characterRepository;
        }


        public async Task Listen(Socket socket, string data)
        {
            var account = await _accountRepository.GetAccount(socket.volatileInformation.accountId);
            List<Character> characters = new List<Character>();
            foreach (var character in account.Characters)
            {
                characters.Add(await _characterRepository.GetCharacter(character));
            }
            socket.Emit(CharactersRequestAlias.CHARACTERS, new CharactersRequest()
            {
                characters = characters
            });
        }
    }
}
