using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.DisconnectReceiver
{
    public class DisconnectReceiver
    {
        public DisconnectReceiver(SocketManager socketManager)
        {
            socketManager.SetDisconnectHandler(DisconnectFactory.Make().Listen);
        }
    }
}
