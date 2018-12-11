using Callisto.Receiver.Common;
using Callisto.Receiver.DisconnectReceiver.Disconnect;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.DisconnectReceiver
{
    public class DisconnectFactory
    {
        private DisconnectFactory() { }

        public static IReceiver Make() => ActivatorUtilities.CreateInstance<OnDisconnectReceiver>(Callisto.Instance().ServiceProvider);
    }
}
