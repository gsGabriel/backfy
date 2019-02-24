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
        public AddSaleCommand(ICollection<AddSaleAlbumCommand> albums)
        {
            Albums = albums;
        }
        
        public ICollection<AddSaleAlbumCommand> Albums { get; }
    }
}
