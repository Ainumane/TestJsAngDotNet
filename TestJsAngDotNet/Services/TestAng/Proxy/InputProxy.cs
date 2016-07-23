namespace TestJsAngDotNet.Services.TestAng.Proxy
{
    using Newtonsoft.Json;

    public class InputProxy
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}