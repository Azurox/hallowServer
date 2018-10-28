using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Receiver.AccountReceiver.Connect;
using Callisto.Receiver.AccountReceiver.CreateCharacter;
using Callisto.Receiver.AccountReceiver.Register;
using Callisto.Receiver.AccountReceiver.SelectCharacter;
using Callisto.Receiver.Common;
using Callisto.Receiver.MapReceiver.LoadMap;
using Microsoft.Extensions.DependencyInjection;
namespace Callisto.Receiver.AccountReceiver
{
    public class AccountReceiverFactory
    {
        private AccountReceiverFactory() { }

        public static IReceiver Make(string eventName)
        {
            switch (eventName)
            {
                case AccountReceiverAlias.REGISTER:
                    return ActivatorUtilities.CreateInstance<RegisterReceiver>(Callisto.Instance().ServiceProvider);
                case AccountReceiverAlias.CONNECT:
                    return ActivatorUtilities.CreateInstance<ConnectReceiver>(Callisto.Instance().ServiceProvider);
                case AccountReceiverAlias.CREATE_CHARACTER:
                    return ActivatorUtilities.CreateInstance<CreateCharacterReceiver>(Callisto.Instance().ServiceProvider);
                case AccountReceiverAlias.SELECT_CHARACTER:
                    return ActivatorUtilities.CreateInstance<SelectCharacterReceiver>(Callisto.Instance().ServiceProvider);
                default:
                    return null;
            }
        }
    }
}