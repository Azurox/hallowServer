using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.AccountReceiver.SelectCharacter
{
    public class SelectCharacterRequestAlias
    {
        private SelectCharacterRequestAlias() { }
        public const string SELECT_CHARACTER = "account/selectCharacter";
        public const string GO_TO_WORLD = "account/goToWorld";
    }
}