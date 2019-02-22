using Backfy.Albums.Query.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Albums.Query.Handler
{
    /// <summary>
    /// QueryHandler to get a albums by filter and pagination
    /// </summary>
    public class GetPaginatedAlbumsQueryHandler : IRequestHandler<GetPaginatedAlbumsQuery, IEnumerable<GetPaginatedAlbumsQueryResult>>
    {
        /// <summary>
        /// The handle to get requested albums
        /// </summary>
        /// <param name="request">The request with filter and pagination params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested albums</returns>
        public Task<IEnumerable<GetPaginatedAlbumsQueryResult>> Handle(GetPaginatedAlbumsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
