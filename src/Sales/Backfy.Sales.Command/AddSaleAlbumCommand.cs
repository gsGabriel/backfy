using Backfy.Sales.Command.Result;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backfy.Sales.Command
{
    /// <summary>
    /// Command to add a Sale
    /// </summary>
    public class AddSaleAlbumCommand
    {
        public AddSaleAlbumCommand(string id, string genre, decimal price)
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
