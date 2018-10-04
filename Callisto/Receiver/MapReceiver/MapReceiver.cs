using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MapReceiver
{
    public class MapReceiver
    {
        public MapReceiver(SocketManager socketManager)
        {
            socketManager.On(MapReceiverAlias.LOAD_MAP, MapReceiverFactory.Make(MapReceiverAlias.LOAD_MAP).Listen);
        }

    }
}
