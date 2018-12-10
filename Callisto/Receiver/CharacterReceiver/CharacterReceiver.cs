using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.CharacterReceiver
{
    public class CharacterReceiver
    {
        public CharacterReceiver(SocketManager socketManager)
        {
            socketManager.On(CharacterReceiverAlias.CHARACTERS_ON_MAP, CharacterReceiverFactory.Make(CharacterReceiverAlias.CHARACTERS_ON_MAP).Listen);
        }
    }
}
