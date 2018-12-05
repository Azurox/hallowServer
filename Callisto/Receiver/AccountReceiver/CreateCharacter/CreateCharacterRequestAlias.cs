using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.CreateCharacter
{
    public class CreateCharacterRequestAlias
    {
        private CreateCharacterRequestAlias() { }
        public const string NAME_ALREADY_TAKEN = "account/nameAlreadyTaken";
        public const string GO_TO_WORLD = "account/goToWorld";
    }
}
