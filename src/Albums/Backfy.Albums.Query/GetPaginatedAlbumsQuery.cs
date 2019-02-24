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
        /// Initializes a new instance of the <see cref="GetPaginatedAlbumsQuery"/> class.
        /// </summary>
        /// <param name="genre">The genre name</param>
        /// <param name="skip">The actual page</param>
        /// <param name="take">The number of elements to take</param>
        public GetPaginatedAlbumsQuery(string genre, int skip, int take)
        {
            Genre = genre;
            this.Skip = skip;
            this.Take = take;
        }

        /// <summary>
        /// The genre name
        /// </summary>
        public string Genre { get; }
    }
}
