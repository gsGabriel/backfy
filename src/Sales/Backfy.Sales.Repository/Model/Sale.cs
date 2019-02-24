using System;
using System.Collections.Generic;

namespace Backfy.Sales.Repository.Model
{
    /// <summary>
    /// The representation of sale
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class.
        /// </summary>
        /// <param name="albums">List of albums in a sale <see cref="SaleAlbum"/></param>
        public Sale(IEnumerable<SaleAlbum> albums)
        {
            Id = Guid.NewGuid();
            Albums = albums;
            DateSale = DateTime.Now;
        }
        
        /// <summary>
        /// The sale identifier
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// List of albums in a sale
        /// </summary>
        public IEnumerable<SaleAlbum> Albums { get; }

        /// <summary>
        /// The date of sale
        /// </summary>
        public DateTime DateSale { get; }
    }
}
