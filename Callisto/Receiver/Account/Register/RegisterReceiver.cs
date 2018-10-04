using Callisto.Database.Models;
using Callisto.Receiver.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Receiver.AccountReceiver.Register
{
    public class RegisterReceiver : IReceiver
    {
        private readonly IAccountRepository _accountRepository;
        public RegisterReceiver(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        internal class Request
        {
            public string Email;
            public string Password;
        }
        public void Listen(Socket socket, string data)
        {
            var request = JsonConvert.DeserializeObject<Request>(data);
        }
    }
}