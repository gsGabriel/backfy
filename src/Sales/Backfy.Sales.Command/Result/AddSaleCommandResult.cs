using System;
using System.Collections.Generic;
using System.Linq;

namespace Backfy.Sales.Command.Result
{
    /// <summary>
    /// CommandResult of a added sale
    /// </summary>
    public class AddSaleCommandResult
    {
        public AddSaleCommandResult(Guid id, DateTime dateSale, ICollection<AddSaleAlbumsCommandResult> albums)
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

        public ICollection<AddSaleAlbumsCommandResult> Albums { get; }
    }
}
