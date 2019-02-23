using System;
using System.Collections.Generic;
using System.Linq;

namespace Backfy.Sales.Query.Result
{
    /// <summary>
    /// QueryResult to get a specified Sale
    /// </summary>
    public class GetPaginatedSalesQueryResult
    {
        public GetPaginatedSalesQueryResult(Guid id, DateTime dateSale, ICollection<GetPaginatedSalesAlbumsQueryResult> albums)
        {
            Id = id;
            DateSale = dateSale;
            Albums = albums;
        }

        public Guid Id { get; }
        public DateTime DateSale { get; }
        public decimal Total
        {
            get
            {
                return this.Albums.Select(x => x.Price).Sum();
            }
        }
        public decimal TotalCashback
        {
            get
            {
                return this.Albums.Select(x => x.Cashback).Sum();
            }
        }

        public ICollection<GetPaginatedSalesAlbumsQueryResult> Albums { get; }
    }
}
