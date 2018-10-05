﻿using Callisto.Database.Models;
using Callisto.Receiver.Common;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Callisto.Database.Models;


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

        public async Task Listen(Socket socket, string data)
        {
            var request = JsonConvert.DeserializeObject<Request>(data);
            if (await _accountRepository.AccountExist(request.Email))
            {
                await _accountRepository.Create(new Database.Models.Account{Email = request.Email, Password = request.Password});
            }
            else
            {
                Console.WriteLine("account already exist !");
            }
        }
    }
}