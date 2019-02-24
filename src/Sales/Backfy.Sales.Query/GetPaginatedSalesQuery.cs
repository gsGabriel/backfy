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
    public class GetPaginatedSalesQuery : PaginationQuery, IRequest<PaginationQueryResult<GetPaginatedSalesQueryResult>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPaginatedSalesQuery"/> class.
        /// </summary>
        /// <param name="startDate">The start date range for date sale</param>
        /// <param name="endDate">The end date range for date sale</param>
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
        /// The start date range for date sale
        /// </summary>
        public DateTime? StartDate { get; }

        /// <summary>
        /// The end date range for date sale
        /// </summary>
        public DateTime? EndDate { get; }
    }
}
