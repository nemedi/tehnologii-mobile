using System.Net.WebSockets;
using System.Threading.Tasks.Dataflow;

namespace Chat.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseUrls("http://localhost:6969/");
            var application = builder.Build();
            application.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromMinutes(10)
            });
            application.UseRouting();
            application.MapGet("/", () => "It's working!");
            var webSockets = new List<WebSocket>();
            application.Map("/chat", async context =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
                    {
                        webSockets.Add(webSocket);
                        var buffer = new byte[1024 * 4];
                        var receiveResult = await webSocket.ReceiveAsync(
                            new ArraySegment<byte>(buffer), CancellationToken.None);

                        while (!receiveResult.CloseStatus.HasValue)
                        {
                            webSockets.ForEach(async ws =>
                                await webSocket.SendAsync(
                                    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                                    receiveResult.MessageType,
                                    receiveResult.EndOfMessage,
                                    CancellationToken.None)
                            );
                            receiveResult = await webSocket.ReceiveAsync(
                                new ArraySegment<byte>(buffer), CancellationToken.None);
                        }

                        await webSocket.CloseAsync(
                            receiveResult.CloseStatus.Value,
                            receiveResult.CloseStatusDescription,
                            CancellationToken.None);
                        webSockets.Remove(webSocket);
                    }
                }
            });
            application.Run();
        }
    }
}