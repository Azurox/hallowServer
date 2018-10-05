using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.Connect
{
    public class ConnectRequestAlias
    {
        private ConnectRequestAlias() { }
        public const string WRONG_CREDENTIAL = "account/wrongCredential";
        public const string GO_TO_SELECT_CHARACTER = "account/goToSelectCharacter";
    }
}
