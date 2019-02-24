namespace Backfy.Sales.Command.Result
{
    /// <summary>
    /// CommandResult of a albums in sale
    /// </summary>
    public class AddSaleAlbumsCommandResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddSaleAlbumsCommandResult"/> class.
        /// </summary>
        /// <param name="id">The album identifier</param>
        /// <param name="price">The album price</param>
        /// <param name="cashback">The album cashback of sale</param>
        public AddSaleAlbumsCommandResult(string id, decimal price, decimal cashback)
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
