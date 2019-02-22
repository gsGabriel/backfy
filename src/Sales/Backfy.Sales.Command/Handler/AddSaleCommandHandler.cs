using Backfy.Sales.Command.Result;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Sales.Command.Handler
{
    /// <summary>
    /// QueryHandler to add a sale
    /// </summary>
    public class AddSaleCommandHandler : IRequestHandler<AddSaleCommand, AddSaleCommandResult>
    {
        /// <summary>
        /// The handle to add a Sale
        /// </summary>
        /// <param name="request">The request with filter params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the result of Sale</returns>
        public Task<AddSaleCommandResult> Handle(AddSaleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
