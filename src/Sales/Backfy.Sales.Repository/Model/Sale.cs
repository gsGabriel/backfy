using System;
using System.Collections.Generic;

namespace Backfy.Sales.Repository.Model
{
    public class Sale
    {
        public Sale(IEnumerable<SaleAlbum> albums)
        {
            Id = Guid.NewGuid();
            Albums = albums;
            DateSale = DateTime.Now;
        }
        
        public Guid Id { get; }
        public IEnumerable<SaleAlbum> Albums { get; }
        public DateTime DateSale { get; }
    }
}
