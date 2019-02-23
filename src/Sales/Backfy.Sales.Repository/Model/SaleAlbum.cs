namespace Backfy.Sales.Repository.Model
{
    public class SaleAlbum
    {
        public SaleAlbum(string id, string genre, decimal price)
        {
            Id = id;
            Genre = genre;
            Price = price;
        }

        public string Id { get; }
        public string Genre { get; }
        public decimal Price { get; }
    }
}
