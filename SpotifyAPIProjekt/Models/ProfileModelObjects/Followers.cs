using Newtonsoft.Json;

namespace SpotifyAPIProjekt.Models.ProfileModelObjects
{
    public class Followers
    {
        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }
}
