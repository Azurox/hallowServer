using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.Register
{
    public class RegisterRequestAlias
    {
        private RegisterRequestAlias() { }
        public const string EMAIL_ALREADY_TAKEN = "account/emailAlreadyTaken";
        public const string ACCOUNT_CREATED = "account/accountCreated";

    }
}
