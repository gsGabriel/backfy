using Backfy.Albums.Query.Result;
using Backfy.Common.Infra.Helpers;
using Backfy.Common.Infra.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Albums.Query.Handler
{
    /// <summary>
    /// QueryHandler to get a albums by filter and pagination
    /// </summary>
    public class GetPaginatedAlbumsQueryHandler : IRequestHandler<GetPaginatedAlbumsQuery, IEnumerable<GetPaginatedAlbumsQueryResult>>
    {
        private readonly ISpotifyService spotifyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPaginatedAlbumsQueryHandler"/> class.
        /// </summary>
        /// <param name="spotifyService">The spotify service dependency</param>
        public GetPaginatedAlbumsQueryHandler(ISpotifyService spotifyService)
        {
            this.spotifyService = spotifyService;
        }

        /// <summary>
        /// The handle to get requested albums
        /// </summary>
        /// <param name="request">The request with filter and pagination params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested albums</returns>
        public async Task<IEnumerable<GetPaginatedAlbumsQueryResult>> Handle(GetPaginatedAlbumsQuery request, CancellationToken cancellationToken)
        {
            var offset = (request.Skip * request.Take) + 1;
            var albums = await spotifyService.GetAlbumsAsync(request.Genre, request.Take, offset);
            cancellationToken.ThrowIfCancellationRequested();

            return await Task.FromResult(albums.Select(x => new GetPaginatedAlbumsQueryResult(x.Id, x.Name, x.ReleaseDate, x.TotalTracks, RandomPricesHelper.GetPrice())).OrderBy(x => x.Name));
        }
    }
}
