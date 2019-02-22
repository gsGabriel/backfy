using Backfy.Albums.Query.Result;
using Backfy.Common.Infra.Pagination;
using MediatR;
using System.Collections.Generic;

namespace Backfy.Albums.Query
{
    /// <summary>
    /// Query to get a albums by filter and pagination
    /// </summary>
    public class GetPaginatedAlbumsQuery : PaginationQuery, IRequest<IEnumerable<GetPaginatedAlbumsQueryResult>>
    {
        /// <summary>
        /// Get a albums by filter and pagination
        /// </summary>
        /// <param name="genre">The genre filter</param>
        /// <param name="skip">The actual page</param>
        /// <param name="take">The number of elements to take</param>
        public GetPaginatedAlbumsQuery(string genre, int skip, int take)
        {
            Genre = genre;
            this.Skip = skip;
            this.Take = take;
        }

        /// <summary>
        /// The genre filter
        /// </summary>
        public string Genre { get; }
    }
}
