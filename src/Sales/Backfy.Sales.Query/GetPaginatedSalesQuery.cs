using Backfy.Sales.Query.Result;
using Backfy.Common.Infra.Pagination;
using MediatR;
using System.Collections.Generic;
using System;

namespace Backfy.Sales.Query
{
    /// <summary>
    /// Query to get a Sales by filter and pagination
    /// </summary>
    public class GetPaginatedSalesQuery : PaginationQuery, IRequest<IEnumerable<GetPaginatedSalesQueryResult>>
    {
        /// <summary>
        /// Get a Sales by filter and pagination
        /// </summary>
        /// <param name="startDate">The start date filter</param>
        /// <param name="endDate">The end date filter</param>
        /// <param name="skip">The actual page</param>
        /// <param name="take">The number of elements to take</param>
        public GetPaginatedSalesQuery(DateTime? startDate, DateTime? endDate, int skip, int take)
        {
            this.Skip = skip;
            this.Take = take;
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// The start date filter
        /// </summary>
        public DateTime? StartDate { get; }
        
        /// <summary>
        /// The end date filter
        /// </summary>
        public DateTime? EndDate { get; }
    }
}
