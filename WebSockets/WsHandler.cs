using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using System.Web.WebSockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace WebSockets
{
    public class WsHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                var u = new User();

                context.AcceptWebSocketRequest(u.Receiver);
            }
        }
    }

    public class User
    {
        private AspNetWebSocketContext _context;
        public async Task Receiver(AspNetWebSocketContext arg)
        {
            var socket = _context.WebSocket;

            try
            {
                while (true)
                {
                    ArraySegment<byte> buffer = new ArraySegment<byte>();
                    await socket.ReceiveAsync(buffer, CancellationToken.None);

                    if (socket.State != WebSocketState.Open)
                    {
                        ChatRoom.Leave(this);
                        break;
                    }

                    var msg = JsonConvert.DeserializeObject<ChatMessage>(Encoding.UTF8.GetString(buffer.ToArray()));
                    ChatRoom.Message(msg);
                }
            }
            catch (Exception ex)
            {
                ChatRoom.Leave(this);
            }
        }

        /// <summary>
        /// Sends message through web socket to player's rowser
        /// </summary>
        public async Task SendMessage(object message)
        {
            // serialize and send
            var messageString = JsonConvert.SerializeObject(message);
            if (_context != null && _context.WebSocket.State == WebSocketState.Open)
            {
                var outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(messageString));
                await _context.WebSocket.SendAsync(outputBuffer, WebSocketMessageType.Text,
                    true, CancellationToken.None);
            }
        }
    }

    public static class ChatRoom
    {
        private static List<User> _users;

        static ChatRoom()
        {
            _users = new List<User>();
        }

        public static void Join(User u)
        {
            _users.Add(u);
        }

        public static void Leave(User u)
        {
            _users.Remove(u);
        }

        public static void Message(ChatMessage m)
        {
            foreach (var u in _users)
            {
                u.SendMessage(m);
            }
        }
    }
}