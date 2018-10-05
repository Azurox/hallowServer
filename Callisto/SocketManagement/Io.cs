using Callisto.Receiver.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.SocketManagement
{
    public class Io
    {
        private readonly SocketGateway _socketGateway;
        private readonly Dictionary<string, List<Guid>> _rooms = new Dictionary<string, List<Guid>>();

        public Io(SocketGateway socketGateway)
        {
            _socketGateway = socketGateway;
        }

        public void Join(string roomName, Guid guid)
        {
            if (_rooms.ContainsKey(roomName))
            {
                _rooms[roomName].Add(guid);
            }
            else
            {
                _rooms[roomName] = new List<Guid> { guid };
            }
        }

        public void Leave(string roomName, Guid guid)
        {
            if (_rooms.ContainsKey(roomName))
            {
                _rooms[roomName].Remove(guid);
            }
        }

        public void Emit(Guid guid, string eventName, IRequest request)
        {
            _socketGateway.SocketManager.Emit(guid, eventName, JsonConvert.SerializeObject(request));
        }

        public void Emit(string roomName, string eventName, IRequest request)
        {
            if (_rooms.ContainsKey(roomName))
            {
                var requestJson = JsonConvert.SerializeObject(request);
                foreach (var guid in _rooms[roomName])
                {
                    _socketGateway.SocketManager.Emit(guid, eventName, requestJson);
                }
            }
        }

    }
}
