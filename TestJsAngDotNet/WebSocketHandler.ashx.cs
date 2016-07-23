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
    using Models;
    using System.Linq;
    using System.Collections.Generic;

    public class WebSocketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(AsyncHandle);
            }
        }

        public bool IsReusable { get { return false; } }

        public async Task AsyncHandle(AspNetWebSocketContext context)
        {
            WebSocket webSocket = context.WebSocket;

            while (webSocket.State == WebSocketState.Open)
            {
                var byteData = new ArraySegment<byte>(new byte[1024]);
                var data = await webSocket.ReceiveAsync(byteData, CancellationToken.None);

                var proxy = JsonConvert.DeserializeObject<WebSocketProxy>(System.Text.UTF8Encoding.UTF8.GetString(byteData.Array));
                string outputJson;

                if (proxy.Action == Enums.WebsocketAction.GetList)
                {
                    var listData = new List<InputProxy>();
                    using (var db = new DataContext())
                    {
                        try
                        {
                            listData = db.ListDatas.Select(s => new InputProxy
                            {
                                Id = s.Id,
                                Name = s.Name
                            }).ToList();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    outputJson = JsonConvert.SerializeObject(new WebSocketProxy(Enums.WebsocketAction.GetList, listData));
                }
                else
                {
                    //заменить на сервис получения данных из БД
                    OutputProxy proxyInfo;

                    using (var db = new DataContext())
                    {
                        try
                        {
                            var dbInfo = db.DataInfos
                                .First(x => x.ListDataId == ((long)(proxy.Data)));

                            proxyInfo = new OutputProxy
                            {
                                Text1 = dbInfo.Text1,
                                Text2 = dbInfo.Text2,
                                IntField1 = dbInfo.IntField1
                            };
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    outputJson = JsonConvert.SerializeObject(new WebSocketProxy(Enums.WebsocketAction.GetInfo, proxyInfo));
                }

                byteData = new ArraySegment<byte>(System.Text.UTF8Encoding.UTF8.GetBytes(outputJson));
                await webSocket.SendAsync(byteData, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}