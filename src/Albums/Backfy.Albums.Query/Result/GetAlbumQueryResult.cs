using System;

namespace Backfy.Albums.Query.Result
{
    /// <summary>
    /// QueryResult of a specified album
    /// </summary>
    public class GetAlbumQueryResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAlbumQueryResult"/> class.
        /// </summary>
        /// <param name="id">the album identifier</param>
        /// <param name="name">The album name</param>
        /// <param name="releaseDate">The album release date</param>
        /// <param name="totalTracks">The total tracks of album</param>
        /// <param name="price">The price of album</param>
        public GetAlbumQueryResult(string id, string name, string releaseDate, int totalTracks, decimal price)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            TotalTracks = totalTracks;
            Price = price;
        }

        /// <summary>
        /// The album identifier
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The album name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The album release date
        /// </summary>
        public string ReleaseDate { get; }

        /// <summary>
        /// The total tracks of album
        /// </summary>
        public int TotalTracks { get; }

        /// <summary>
        /// The price of album
        /// </summary>
        public decimal Price { get; }
    }
}
