﻿namespace Backfy.Sales.Query.Result
{
    public class GetPaginatedSalesAlbumsQueryResult
    {
        public GetPaginatedSalesAlbumsQueryResult(string id, decimal price, decimal cashback)
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
