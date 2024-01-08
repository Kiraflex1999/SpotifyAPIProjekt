using Newtonsoft.Json;

namespace SpotifyAPIProjekt.Models.ProfileModelObjects
{
    public class Images
    {
        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("widht")]
        public int? Width { get; set; }
    }
}
