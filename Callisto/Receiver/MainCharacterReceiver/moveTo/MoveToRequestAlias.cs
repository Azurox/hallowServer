using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MainCharacterReceiver.moveTo
{
    public class MoveToRequestAlias
    {
        private MoveToRequestAlias() { }
        public const string ILLEGAL_MOVEMENT = "mainCharacter/illegalMovement";
        public const string LEGAL_MOVEMENT = "mainCharacter/legalMovement";
    }
}
