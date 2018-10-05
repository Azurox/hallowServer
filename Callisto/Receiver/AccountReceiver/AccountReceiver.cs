using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Callisto.Receiver.AccountReceiver
{
    public class AccountReceiver
    {
        public AccountReceiver(SocketManager socketManager)
        {
            socketManager.On(AccountReceiverAlias.CONNECT, AccountReceiverFactory.Make(AccountReceiverAlias.CONNECT).Listen);
            socketManager.On(AccountReceiverAlias.REGISTER, AccountReceiverFactory.Make(AccountReceiverAlias.REGISTER).Listen);
            //socketManager.On(AccountReceiverAlias.CREATE_CHARACTER, AccountReceiverFactory.Make(AccountReceiverAlias.CREATE_CHARACTER).Listen);
            //socketManager.On(AccountReceiverAlias.SELECT_CHARACTER, AccountReceiverFactory.Make(AccountReceiverAlias.SELECT_CHARACTER).Listen);
        }
    }
}