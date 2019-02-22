using Backfy.Sales.Query.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Sales.Query.Handler
{
    /// <summary>
    /// QueryHandler to get a Sales by filter and pagination
    /// </summary>
    public class GetPaginatedSalesQueryHandler : IRequestHandler<GetPaginatedSalesQuery, IEnumerable<GetPaginatedSalesQueryResult>>
    {
        /// <summary>
        /// The handle to get requested Sales
        /// </summary>
        /// <param name="request">The request with filter and pagination params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested Sales</returns>
        public Task<IEnumerable<GetPaginatedSalesQueryResult>> Handle(GetPaginatedSalesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
