using System;

namespace Backfy.Common.Infra.Services.Models
{
    public class SpotifyAlbum
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TotalTracks { get; set; }
    }
}
