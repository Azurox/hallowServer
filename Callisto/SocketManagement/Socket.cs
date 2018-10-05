using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto
{
    public class Socket
    {
        public Guid Guid { get; set; }

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
