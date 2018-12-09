using Callisto.Receiver.Common;
using Callisto.Receiver.MainCharacterReceiver.Information;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MainCharacterReceiver
{
    public class MainCharacterReceiverFactory
    {
        private MainCharacterReceiverFactory() { }

        public static IReceiver Make(string eventName)
        {
            switch (eventName)
            {
                case MainCharacterReceiverAlias.INFORMATION:
                    return ActivatorUtilities.CreateInstance<InformationReceiver>(Callisto.Instance().ServiceProvider);
                default:
                    return null;
            }
        }
    }
}
