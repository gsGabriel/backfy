namespace Backfy.Sales.Query.Result
{
    /// <summary>
    /// QueryResult of a albums of sale
    /// </summary>
    public class GetSaleAlbumsQueryResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSaleAlbumsQueryResult"/> class.
        /// </summary>
        /// <param name="id">The album identifier</param>
        /// <param name="price">The album price</param>
        /// <param name="cashback">The album cashback of sale</param>
        public GetSaleAlbumsQueryResult(string id, decimal price, decimal cashback)
        {
            Id = id;
            Price = price;
            Cashback = cashback;
        }

        /// <summary>
        /// The album identifier
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The album price
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The album cashback of sale
        /// </summary>
        public decimal Cashback { get; }
    }
}
