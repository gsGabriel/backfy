using Backfy.Sales.Query.Result;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Sales.Query.Handler
{
    /// <summary>
    /// QueryHandler to get a specified Sale
    /// </summary>
    public class GetSaleQueryHandler : IRequestHandler<GetSaleQuery, GetSaleQueryResult>
    {
        /// <summary>
        /// The handle to get requested Sale
        /// </summary>
        /// <param name="request">The request with filter params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested Sale</returns>
        public Task<GetSaleQueryResult> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
