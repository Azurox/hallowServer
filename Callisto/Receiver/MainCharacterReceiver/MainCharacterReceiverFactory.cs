using Callisto.Receiver.Common;
using Callisto.Receiver.MainCharacterReceiver.Information;
using Callisto.Receiver.MainCharacterReceiver.moveTo;
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
                case MainCharacterReceiverAlias.MOVE_TO:
                    return ActivatorUtilities.CreateInstance<MoveToReceiver>(Callisto.Instance().ServiceProvider);
                default:
                    return null;
            }
        }
    }
}
