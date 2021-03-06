﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MainCharacterReceiver
{
    public class MainCharacterReceiver
    {
        public MainCharacterReceiver(SocketManager socketManager)
        {
            socketManager.On(MainCharacterReceiverAlias.INFORMATION, MainCharacterReceiverFactory.Make(MainCharacterReceiverAlias.INFORMATION).Listen);
            socketManager.On(MainCharacterReceiverAlias.MOVE_TO, MainCharacterReceiverFactory.Make(MainCharacterReceiverAlias.MOVE_TO).Listen);
        }
    }
}
