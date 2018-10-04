﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Receiver.Common;
using Callisto.Receiver.MapReceiver.LoadMap;

namespace Callisto.Receiver.MapReceiver
{
    public class MapReceiverFactory
    {
        private MapReceiverFactory() { }
        
        public static IReceiver Make(string eventName)
        {
            switch (eventName)
            {
                case MapReceiverAlias.LOAD_MAP:
                    return new LoadMapReceiver();
                default:
                    return null;
            }
        }

    }
}
