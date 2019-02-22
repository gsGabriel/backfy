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
        public string Id { get; set; }

        /// <summary>
        /// The album name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The album release date
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The total tracks of album
        /// </summary>
        public int TotalTracks { get; set; }
    }
}
