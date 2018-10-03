using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public SocketManager SocketManger { get; set; } = new SocketManager();
    }
}
