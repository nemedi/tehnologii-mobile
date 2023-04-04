using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace Chat.Client.Services
{
    public delegate void ChatMessageReceivedHandler(Models.Message message);
    public class ChatService
    {
        string user;
        ClientWebSocket webSocket;

        public void Login(string user, string endpoint)
        {
            this.user = user;
            Task.Run(async () =>
            {
                using (webSocket = new ClientWebSocket())
                {
                    await webSocket.ConnectAsync(new Uri(endpoint), CancellationToken.None);
                    var buffer = new byte[1024 * 4];
                    while (webSocket.State == WebSocketState.Open)
                    {
                        var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
                        }
                        else
                        {
                            var data = Encoding.ASCII.GetString(buffer, 0, result.Count);
                            var messge = JsonSerializer.Deserialize<Models.Message>(data);
                            MessageReceived?.Invoke(messge);
                        }
                    }
                }
            });
        }

        public async Task LogoutAsync()
        {
            if (webSocket != null)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                    string.Empty,
                    CancellationToken.None);
            }
        }

        public async Task SendMessageAsync(string content)
        {
            if (webSocket != null)
            {
                var message = new Models.Message
                {
                    User = user,
                    Content = content
                };
                var data = JsonSerializer.Serialize(message);
                var buffer = Encoding.ASCII.GetBytes(data);
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, buffer.Length),
                    WebSocketMessageType.Text,
                    false,
                    CancellationToken.None);
            }
        }

        public event ChatMessageReceivedHandler MessageReceived;
    }
}
