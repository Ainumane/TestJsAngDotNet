namespace TestJsAngDotNet.Services.WebSocket.Proxy
{
    using Newtonsoft.Json;
    using Enums;
    public class WebSocketProxy
    {
        public WebSocketProxy() { }
        public WebSocketProxy(WebsocketAction action, object data)
        {
            Action = action;
            Data = data;
        }

        [JsonProperty("action")]
        public WebsocketAction Action;

        [JsonProperty("data")]
        public object Data;
    }
}