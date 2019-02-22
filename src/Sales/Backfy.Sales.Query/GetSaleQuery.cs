using Backfy.Sales.Query.Result;
using MediatR;

namespace Backfy.Sales.Query
{
    /// <summary>
    /// Query to get a specified Sale
    /// </summary>
    public class GetSaleQuery : IRequest<GetSaleQueryResult>
    {
        /// <summary>
        /// Get a specified Sale
        /// </summary>
        /// <param name="id">The identifier of Sale</param>
        public GetSaleQuery(string id)
        {
            Id = id;
        }

        /// <summary>
        /// The identifier of Sale
        /// </summary>
        public string Id { get; }
    }
}
