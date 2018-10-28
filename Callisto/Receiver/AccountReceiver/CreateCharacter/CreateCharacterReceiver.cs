using Callisto.Database.Models.AccountModel;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.CreateCharacter
{
    public class CreateCharacterReceiver : IReceiver
    {
        private readonly IAccountRepository _accountRepository;
        public CreateCharacterReceiver(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        internal class Request
        {
            public string CharacterName;
        }

        public Task Listen(Socket socket, string data)
        {
            throw new NotImplementedException();
        }
    }
}
