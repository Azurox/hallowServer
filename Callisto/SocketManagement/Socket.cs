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

        private HashSet<string> rooms = new HashSet<string>();

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

        public void Join(string roomName)
        {
            rooms.Add(roomName);
            Callisto.Instance().Io.Join(roomName, Guid);
        }

        public void Leave(string roomName)
        {
            rooms.Remove(roomName);
            Callisto.Instance().Io.Leave(roomName, Guid);
        }

        public void LeaveAll()
        {
            foreach (var room in rooms)
            {
                Callisto.Instance().Io.Leave(room, Guid);
            }
            rooms = new HashSet<string>();
        }

        public void EmitTo(string roomName, string eventName, IRequest request)
        {
            Callisto.Instance().Io.Emit(roomName, eventName, request);
        }

        public void Broadcast(string roomName, string eventName, IRequest request)
        {
            Callisto.Instance().Io.Broadcast(roomName, Guid, eventName, request);
        }
    }
}
