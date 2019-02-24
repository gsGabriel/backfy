using Backfy.Sales.Command.Result;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backfy.Sales.Command
{
    /// <summary>
    /// Command to add a Sale
    /// </summary>
    public class AddSaleCommand : IRequest<AddSaleCommandResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddSaleCommand"/> class.
        /// </summary>
        /// <param name="albums">List of albums in a sale <see cref="AddSaleAlbumCommand"/></param>
        public AddSaleCommand(ICollection<AddSaleAlbumCommand> albums)
        {
            Albums = albums;
        }
        
        /// <summary>
        /// List of albums in a sale <see cref="AddSaleAlbumCommand"/>
        /// </summary>
        public ICollection<AddSaleAlbumCommand> Albums { get; }
    }
}
