using Newtonsoft.Json;

namespace TestJsAngDotNet.Services.TestAng.Proxy
{
    public class OutputProxy
    {
        [JsonProperty("text1")]
        public string Text1;

        [JsonProperty("text2")]
        public string Text2;

        [JsonProperty("intField1")]
        public int IntField1;
    }
}