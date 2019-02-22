using Backfy.Common.Infra.Services.Interfaces;
using Backfy.Common.Infra.Services.Models;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backfy.Common.Infra.Services
{
    /// <summary>
    /// The sportify service integration
    /// </summary>
    public class SpotifyService : ISpotifyService
    {
        private readonly string uriApiSpotify = "https://api.spotify.com/v1/";

        /// <inheritdoc />
        public async Task<SpotifyAlbum> GetAlbumAsync(string id)
        {
            var result = await GetAlbum(id);
            return new SpotifyAlbum { Id = result.id, Name = result.name, ReleaseDate = result.release_date, TotalTracks = result.total_tracks };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SpotifyAlbum>> GetAlbumsAsync(string query, int limit, int offset)
        {
            var result = await Search(query, "album", limit, offset);
            IEnumerable<dynamic> albums = result.albums.items;

            return albums.Select(x => new SpotifyAlbum { Id = x.id, Name = x.name, ReleaseDate = x.release_date, TotalTracks = x.total_tracks }).ToList();
        }

        private Task<dynamic> GetAlbum(string id)
        {
            return uriApiSpotify
                .AppendPathSegment("albums")
                .SetQueryParams(id)
                .WithOAuthBearerToken("my_oauth_token")
                .GetJsonAsync<dynamic>();
        }

        private Task<dynamic> Search(string query, string type, int limit, int offset)
        {
            return uriApiSpotify
                .AppendPathSegment("search")
                .SetQueryParams($"q={query}&type={type}&market=from_token&limit={limit}&offset={1}")
                .WithOAuthBearerToken("my_oauth_token")
                .GetJsonAsync<dynamic>();
        }
    }
}
