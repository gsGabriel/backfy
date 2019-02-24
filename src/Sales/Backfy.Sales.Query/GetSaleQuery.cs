using Backfy.Sales.Query.Result;
using MediatR;
using System;

namespace Backfy.Sales.Query
{
    /// <summary>
    /// Query to get a specified Sale
    /// </summary>
    public class GetSaleQuery : IRequest<GetSaleQueryResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSaleQuery"/> class.
        /// </summary>
        /// <param name="id">The identifier of Sale</param>
        public GetSaleQuery(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// The identifier of Sale
        /// </summary>
        public Guid Id { get; }
    }
}
