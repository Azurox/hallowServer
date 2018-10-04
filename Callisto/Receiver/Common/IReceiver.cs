using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.Common
{
    public interface IReceiver
    {
        void Listen(Socket socket, string data);
    }
}
