using Newtonsoft.Json;
using System;

namespace Backfy.Common.Infra.Services.Models
{
    /// <summary>
    /// The spotify model of album
    /// </summary>
    public class SpotifyAlbum
    {
        /// <summary>
        /// The album identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The album name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The album release date
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The total tracks of album
        /// </summary>
        [JsonProperty("total_tracks")]
        public int TotalTracks { get; set; }
    }
}
