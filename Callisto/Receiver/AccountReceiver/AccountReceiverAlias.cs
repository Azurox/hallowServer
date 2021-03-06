﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Receiver.AccountReceiver
{
    public class AccountReceiverAlias
    {
        private AccountReceiverAlias() { }
        public const string REGISTER = "account/register";
        public const string CONNECT = "account/connect";
        public const string CHARACTERS = "account/characters";
        public const string CREATE_CHARACTER = "account/createCharacter";
        public const string SELECT_CHARACTER = "account/selectCharacter";
    }
}