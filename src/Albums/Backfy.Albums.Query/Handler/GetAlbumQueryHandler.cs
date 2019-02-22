using Backfy.Albums.Query.Result;
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
        /// <summary>
        /// The handle to get requested album
        /// </summary>
        /// <param name="request">The request with filter params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested album</returns>
        public Task<GetAlbumQueryResult> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
