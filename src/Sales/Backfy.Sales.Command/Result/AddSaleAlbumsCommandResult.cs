namespace Backfy.Sales.Command.Result
{
    public class AddSaleAlbumsCommandResult
    {
        public AddSaleAlbumsCommandResult(string id, decimal price, decimal cashback)
        {
            Id = id;
            Price = price;
            Cashback = cashback;
        }

        public string Id { get; }
        public decimal Price { get; }
        public decimal Cashback { get; }
    }
}
