namespace SpotifyAPIProjekt.Models
{
    public class PlaylistModel
    {
        public dynamic DynamicModel { get; init; }
        public string PlaylistId { get; init; }
        public int NextTrackIndex{ get; init; }

        public PlaylistModel(dynamic dynamicModel, string playlistId, int nextTrackIndex)
        {
            DynamicModel = dynamicModel;
            PlaylistId = playlistId;
            NextTrackIndex = nextTrackIndex;
        }
    }
}
