﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Callisto
{
    public class SocketGateway
    {
        private readonly ConcurrentDictionary<Guid, WebSocket> _webSockets = new ConcurrentDictionary<Guid, WebSocket>();
        private SocketManager _socketManager;

        public SocketGateway()
        {
            _socketManager = new SocketManager(this);
        }

        public async Task Listen(HttpContext context, WebSocket webSocket)
        {
            var socketGuid = Guid.NewGuid();
            context.Items.Add("id", socketGuid);
            _webSockets[socketGuid] = webSocket;
            _socketManager.RegisterSocket(socketGuid);
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                ProcessMessage(socketGuid, buffer, result);

                buffer = new byte[1024 * 4];// reset the buffer
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        private void ProcessMessage(Guid guid, byte[] buffer, WebSocketReceiveResult result)
        {
            var str = Encoding.Default.GetString(buffer).Substring(0, result.Count);
            _socketManager.ProcessMessage(guid, str);
        }

        public async void SendMessage(Guid guid, string message)
        {
            if(_webSockets.TryGetValue(guid, out var webSocket))
            {
                await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message), 0, message.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}