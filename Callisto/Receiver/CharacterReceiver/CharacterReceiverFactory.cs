using Callisto.Receiver.CharacterReceiver.CharactersOnMap;
using Callisto.Receiver.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.CharacterReceiver
{
    public class CharacterReceiverFactory
    {
        private CharacterReceiverFactory() { }

        public static IReceiver Make(string eventName)
        {
            switch (eventName)
            {
                case CharacterReceiverAlias.CHARACTERS_ON_MAP:
                    return ActivatorUtilities.CreateInstance<CharactersOnMapReceiver>(Callisto.Instance().ServiceProvider);
                default:
                    return null;
            }
        }
    }
}
