using Callisto.Database.Models.AccountModel;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.SelectCharacter
{
    public class SelectCharacterReceiver: IReceiver
    {
        private readonly IAccountRepository _accountRepository;
        public SelectCharacterReceiver(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        internal class Request
        {
            public string name;
        }

        public Task Listen(Socket socket, string data)
        {
            throw new NotImplementedException();
        }
    }
}
