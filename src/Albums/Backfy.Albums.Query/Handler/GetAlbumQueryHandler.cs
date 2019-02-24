using Backfy.Albums.Query.Result;
using Backfy.Common.Infra.Helpers;
using Backfy.Common.Infra.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Albums.Query.Handler
{
    /// <summary>
    /// QueryHandler to get a specified album
    /// </summary>
    public class GetAlbumQueryHandler : IRequestHandler<GetAlbumQuery, GetAlbumQueryResult>
    {
        private readonly ISpotifyService spotifyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAlbumQueryHandler"/> class.
        /// </summary>
        /// <param name="spotifyService">The spotify service depencency</param>
        public GetAlbumQueryHandler(ISpotifyService spotifyService)
        {
            this.spotifyService = spotifyService;
        }

        /// <summary>
        /// The handle to get requested album
        /// </summary>
        /// <param name="request">The request with filter params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested album</returns>
        public async Task<GetAlbumQueryResult> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            BusinessValidation(request);

            var album = await spotifyService.GetAlbumAsync(request.Id);

            return await Task.FromResult(new GetAlbumQueryResult(album.Id, album.Name, album.ReleaseDate, album.TotalTracks, RandomPricesHelper.GetPrice()));
        }

        private void BusinessValidation(GetAlbumQuery request)
        {
            if (string.IsNullOrEmpty(request?.Id))
                throw new Exception("Id inválido");
        }
    }
}
