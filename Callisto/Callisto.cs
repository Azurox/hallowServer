using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Receiver.MapReceiver;

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

        public SocketGateway SocketGateway { get; set; } = new SocketGateway();

        private MapReceiver _mapReceiver;


        public void Init()
        {
            _mapReceiver = new MapReceiver(SocketGateway.SocketManager);
        }
    }
}
