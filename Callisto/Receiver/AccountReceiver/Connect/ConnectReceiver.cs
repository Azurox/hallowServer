using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Database.Models;
using Callisto.Database.Models.AccountModel;
using Callisto.Receiver.Common;
using Newtonsoft.Json;

namespace Callisto.Receiver.AccountReceiver.Connect
{
    public class ConnectReceiver : IReceiver
    {

        private readonly IAccountRepository _accountRepository;
        public ConnectReceiver(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        internal class Request
        {

            public string Email;
            public string Password;
        }

        public async Task Listen(Socket socket, string data)
        {
            var request = JsonConvert.DeserializeObject<Request>(data);
            var account = await _accountRepository.GetAccount(request.Email, request.Password);
            if(account != null)
            {
                socket.Emit(ConnectRequestAlias.GO_TO_SELECT_CHARACTER);
            }
            else
            {
                socket.Emit(ConnectRequestAlias.WRONG_CREDENTIAL);
            }
        }
    }
}
