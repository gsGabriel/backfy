namespace Backfy.Albums.Query.Result
{
    /// <summary>
    /// QueryResult to get a albums by filter and pagination
    /// </summary>
    public class GetPaginatedAlbumsQueryResult
    {
        public GetPaginatedAlbumsQueryResult(string id, string name, string releaseDate, int totalTracks, decimal price)
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
