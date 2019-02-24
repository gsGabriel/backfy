using System;
using System.Collections.Generic;
using System.Linq;

namespace Backfy.Sales.Query.Result
{
    /// <summary>
    /// QueryResult to get paginated sales
    /// </summary>
    public class GetPaginatedSalesQueryResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPaginatedSalesQueryResult"/> class.
        /// </summary>
        /// <param name="id">The sale identifier</param>
        /// <param name="dateSale">The date of sale</param>
        /// <param name="albums">List of albums in a sale <see cref="GetPaginatedSalesAlbumsQueryResult"/></param>
        public GetPaginatedSalesQueryResult(Guid id, DateTime dateSale, ICollection<GetPaginatedSalesAlbumsQueryResult> albums)
        {
            Id = id;
            DateSale = dateSale;
            Albums = albums;
        }

        /// <summary>
        /// The sale identifier
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The date of sale
        /// </summary>
        public DateTime DateSale { get; }

        /// <summary>
        /// The total price of sale
        /// </summary>
        public decimal Total
        {
            get
            {
                return this.Albums.Select(x => x.Price).Sum();
            }
        }

        /// <summary>
        /// The total of cashback of sale
        /// </summary>
        public decimal TotalCashback
        {
            get
            {
                return this.Albums.Select(x => x.Cashback).Sum();
            }
        }

        /// <summary>
        /// List of albums in a sale <see cref="GetPaginatedSalesAlbumsQueryResult"/>
        /// </summary>
        public ICollection<GetPaginatedSalesAlbumsQueryResult> Albums { get; }
    }
}
