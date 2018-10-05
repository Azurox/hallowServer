using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Database.Models;
using Callisto.Receiver.Common;
using Newtonsoft.Json;

namespace Callisto.Receiver.Account.Connect
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
            Console.WriteLine(account != null ? "found account" : "Account not found");
        }
    }
}
