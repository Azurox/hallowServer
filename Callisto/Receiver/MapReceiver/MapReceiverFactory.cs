using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Receiver.Common;

namespace Callisto.Receiver.MapReceiver
{
    public class MapReceiverFactory
    {
        public IReceiver Make(string eventName)
        {
            switch (eventName)
            {
                case MapReceiverAlias.LOAD_MAP:
                    // Insert the factory
                    break;
                default:
                    return null;
            }

            return null;
        }

    }
}
