using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Receiver.AccountReceiver;
using Callisto.Receiver.CharacterReceiver;
using Callisto.Receiver.MainCharacterReceiver;
using Callisto.Receiver.MapReceiver;
using Callisto.SocketManagement;

namespace Callisto
{
    public class Callisto
    {
        #region Singleton

        private Callisto() { }
        private static Callisto _instance;
        public static Callisto Instance()
        {
            if(_instance == null)
            {
                _instance = new Callisto();
            }

            return _instance;
        }
        #endregion

        public SocketGateway SocketGateway { get; } = new SocketGateway();

        public IServiceProvider ServiceProvider { get; set; }

        public Io Io { get; protected set; }

        public State State { get; protected set; }

        #region Receiver
        private MapReceiver _mapReceiver;
        private AccountReceiver _accountReceiver;
        private MainCharacterReceiver _mainCharacterReceiver;
        private CharacterReceiver _characterReceiver;
        #endregion

        public void Init()
        {
            _mapReceiver = new MapReceiver(SocketGateway.SocketManager);
            _accountReceiver = new AccountReceiver(SocketGateway.SocketManager);
            _mainCharacterReceiver = new MainCharacterReceiver(SocketGateway.SocketManager);
            _characterReceiver = new CharacterReceiver(SocketGateway.SocketManager);
            Io = new Io(SocketGateway);
            State = new State();
        }
    }
}
