using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SpotifyAPIProjekt.Models.ProfileModelObjects
{
    public class ExternalUrls
    {
        [JsonProperty("spotify")]
        public string? Spotify {  get; set; }
    }
}
