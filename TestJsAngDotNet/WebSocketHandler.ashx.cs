namespace TestJsAngDotNet
{
    using Newtonsoft.Json;
    using System;
    using System.Net.WebSockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.WebSockets;
    using Services.TestAng.Proxy;
    using Services.WebSocket.Proxy;

    public class WebSocketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest) {
                context.AcceptWebSocketRequest(AsyncHandle);
            }
        }

        public bool IsReusable { get { return false; } }

        public async Task AsyncHandle(AspNetWebSocketContext context)
        {
            WebSocket webSocket = context.WebSocket;

            while (webSocket.State == WebSocketState.Open) {
                var byteData = new ArraySegment<byte>(new byte[1024]);
                var data = await webSocket.ReceiveAsync(byteData, CancellationToken.None);

                var proxy = JsonConvert.DeserializeObject<WebSocketProxy>(System.Text.UTF8Encoding.UTF8.GetString(byteData.Array));

                //заменить на сервис получения данных из БД
                var proxyInfo = new OutputProxy {
                    IntField1 = 13,
                    Text1 = "text 1",
                    Text2 = "text 2"
                };

                var outputJson = JsonConvert.SerializeObject(new WebSocketProxy(Enums.WebsocketAction.GetInfo, proxyInfo));

                byteData = new ArraySegment<byte>(System.Text.UTF8Encoding.UTF8.GetBytes(outputJson));

                await webSocket.SendAsync(byteData, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}