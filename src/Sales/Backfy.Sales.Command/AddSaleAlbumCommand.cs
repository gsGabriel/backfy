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
        /// <summary>
        /// Initializes a new instance of the <see cref="AddSaleAlbumCommand"/> class.
        /// </summary>
        /// <param name="id">the album identifier</param>
        /// <param name="genre">The album genre</param>
        /// <param name="price">The album price</param>
        public AddSaleAlbumCommand(string id, string genre, decimal price)
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
