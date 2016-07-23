using Newtonsoft.Json;

namespace TestJsAngDotNet.Services.TestAng.Proxy
{
    public class InputProxy
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}