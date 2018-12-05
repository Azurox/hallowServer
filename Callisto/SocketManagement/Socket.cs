using Callisto.Receiver.Common;
using Callisto.SocketManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto
{
    public class Socket
    {
        public Guid Guid { get; set; }

        /* Later on, this should be stocked on a Redis DB or passed with a JWT token  */
        public VolatileInformation volatileInformation;

        public Socket(Guid guid)
        {
            Guid = guid;
        }

        public void Emit(string eventName)
        {
            Emit(eventName, new EmptyRequest());
        }

        public void Emit(string eventName, IRequest request)
        {
            Callisto.Instance().Io.Emit(Guid, eventName, request);
        }

    }
}
