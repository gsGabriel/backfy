using Backfy.Common.Infra.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backfy.Common.Infra.Services.Interfaces
{
    /// <summary>
    /// Interface to spotify service
    /// </summary>
    public interface ISpotifyService
    {
        /// <summary>
        /// Take requested albums
        /// </summary>
        /// <param name="query">filter for albums</param>
        /// <param name="limit">limit of requested result</param>
        /// <param name="offset">offset of requested result</param>
        /// <returns>The requested albums</returns>
        Task<IEnumerable<SpotifyAlbum>> GetAlbumsAsync(string query, int limit, int offset);

        /// <summary>
        /// Get a specified album
        /// </summary>
        /// <param name="id">The identifier of album</param>
        /// <returns>The requested specified album</returns>
        Task<SpotifyAlbum> GetAlbumAsync(string id);
    }
}
