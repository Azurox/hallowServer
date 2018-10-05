using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Receiver.Account.Connect;
using Callisto.Receiver.AccountReceiver.Register;
using Callisto.Receiver.Common;
using Callisto.Receiver.MapReceiver.LoadMap;
using Microsoft.Extensions.DependencyInjection;
namespace Callisto.Receiver.MapReceiver
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
                    //return new CreateCharacterReceiver();
                case AccountReceiverAlias.SELECT_CHARACTER:
                    //return new SelectCharacterReceiver();
                default:
                    return null;
            }
        }
    }
}