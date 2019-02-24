namespace Backfy.Sales.Repository.Model
{
    /// <summary>
    /// The representation of association between sale and album
    /// </summary>
    public class SaleAlbum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaleAlbum"/> class.
        /// </summary>
        /// <param name="id">The album identifier</param>
        /// <param name="genre">The album name</param>
        /// <param name="price">The album price</param>
        public SaleAlbum(string id, string genre, decimal price)
        {
            Id = id;
            Genre = genre;
            Price = price;
        }

        /// <summary>
        /// The album identifier
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The album genre
        /// </summary>
        public string Genre { get; }

        /// <summary>
        /// The album price
        /// </summary>
        public decimal Price { get; }
    }
}
