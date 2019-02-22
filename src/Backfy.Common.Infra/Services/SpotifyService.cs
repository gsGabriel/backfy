using Backfy.Common.Infra.Services.Interfaces;
using Backfy.Common.Infra.Services.Models;
using System;
using System.Collections.Generic;

namespace Backfy.Common.Infra.Services
{
    /// <summary>
    /// The sportify service integration
    /// </summary>
    public class SpotifyService : ISpotifyService
    {
        /// <inheritdoc />
        public IEnumerable<SpotifyAlbums> GetAlbums(string query, int limit, int offset)
        {
            throw new NotImplementedException();
        }
    }
}
