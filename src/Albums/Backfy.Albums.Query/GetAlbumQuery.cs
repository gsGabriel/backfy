using Backfy.Albums.Query.Result;
using MediatR;

namespace Backfy.Albums.Query
{
    /// <summary>
    /// Query to get a specified album
    /// </summary>
    public class GetAlbumQuery : IRequest<GetAlbumQueryResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAlbumQuery"/> class.
        /// </summary>
        /// <param name="id">The identifier of album</param>
        public GetAlbumQuery(string id)
        {
            Id = id;
        }

        /// <summary>
        /// The identifier of album
        /// </summary>
        public string Id { get; }
    }
}
