using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Callisto
{
    public class SocketManager
    {
        private readonly Dictionary<string, List<Func<Socket, string, Task>>> _registeredActions = new Dictionary<string, List<Func<Socket, string, Task>>>();

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

        public void On(string eventName, Func<Socket, string, Task> callback)
        {
            if (!_registeredActions.ContainsKey(eventName))
            {
                _registeredActions[eventName] = new List<Func<Socket, string, Task>>();
            }
            _registeredActions[eventName].Add(callback);
        }

        public void Emit(Guid guid, string eventName, string data = "")
        {
            _socketGateway.SendMessage(guid, $"42[\"{eventName}\", {data}]");
        }

        public async void ProcessMessage(Guid guid, string message)
        {
            Console.WriteLine(message);
            if (message.StartsWith("42"))
            {
                var eventAndData = message.Substring(3);
                eventAndData = eventAndData.Remove(eventAndData.Length - 1);
                var eventName = eventAndData.Split(',')[0].Trim('"');
                var data = eventAndData.Remove(0, eventName.Length + 3);
                if (_registeredActions.ContainsKey(eventName))
                {
                    if (_sockets.TryGetValue(guid, out var socket))
                    {
                        foreach (var action in _registeredActions[eventName])
                        {
                            try
                            {
                                await action.Invoke(socket, data);
                            }
                            catch (Exception ex)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex);
                                Console.ResetColor();
                            }
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
