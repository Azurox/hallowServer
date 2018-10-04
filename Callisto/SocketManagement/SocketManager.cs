using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Callisto
{
    public class SocketManager
    {
        private readonly Dictionary<string, List<Action<Socket, string>>> _registeredActions = new Dictionary<string, List<Action<Socket, string>>>();

        private readonly ConcurrentDictionary<Guid, Socket> _sockets = new ConcurrentDictionary<Guid, Socket>();
        private readonly SocketGateway _socketGateway;

        public SocketManager(SocketGateway socketGateway)
        {
            _socketGateway = socketGateway;
        }

        public void RegisterSocket(Guid guid)
        {
            _sockets.TryAdd(guid, new Socket(guid));
        }

        public void On(string eventName, Action<Socket, string> callback)
        {
            if (!_registeredActions.ContainsKey(eventName))
            {
                _registeredActions[eventName] = new List<Action<Socket, string>>();
            }
            _registeredActions[eventName].Add(callback);
        }

        public void Emit(Guid guid, string eventName, string data = "")
        {
            _socketGateway.SendMessage(guid, eventName);
        }

        public void ProcessMessage(Guid guid, string message)
        {
            if (message.StartsWith("42"))
            {
                var eventAndData = message.Substring(3);
                eventAndData = eventAndData.Remove(eventAndData.Length - 1);
                var eventName = eventAndData.Split(',')[0].Trim('"');
                var data = eventAndData.Remove(0, eventName.Length + 3);
                if (_registeredActions.ContainsKey(eventName))
                {
                    if(_sockets.TryGetValue(guid, out var socket))
                    {
                        foreach (var action in _registeredActions[eventName])
                        {
                            action.Invoke(socket, data);       
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Event named " + eventName + " isn't registered !");
                }
            }
            else
            {
                Console.WriteLine("Message => " + message + " isn't allowed yet !");
            }
        }
    }
}
