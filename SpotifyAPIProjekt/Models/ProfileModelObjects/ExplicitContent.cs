using Newtonsoft.Json;

namespace SpotifyAPIProjekt.Models.ProfileModelObjects
{
    public class ExplicitContent
    {
        [JsonProperty("filter_enabled")]
        public bool FilterEnabled {  get; set; }

        [JsonProperty("filter_locked")]
        public string FilterLocked { get; set; }
    }
}
