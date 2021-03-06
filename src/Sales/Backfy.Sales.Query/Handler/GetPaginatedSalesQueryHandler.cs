﻿using Backfy.Albums.Repository.Interfaces;
using Backfy.Common.Infra.Pagination;
using Backfy.Sales.Query.Result;
using Backfy.Sales.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Sales.Query.Handler
{
    /// <summary>
    /// QueryHandler to get a Sales by filter and pagination
    /// </summary>
    public class GetPaginatedSalesQueryHandler : IRequestHandler<GetPaginatedSalesQuery, PaginatedQueryResult<GetPaginatedSalesQueryResult>>
    {
        private readonly ISaleRepository saleRepository;
        private readonly IGenreRepository genreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPaginatedSalesQueryHandler"/> class.
        /// </summary>
        /// <param name="saleRepository"></param>
        /// <param name="genreRepository"></param>
        public GetPaginatedSalesQueryHandler(ISaleRepository saleRepository, IGenreRepository genreRepository)
        {
            this.saleRepository = saleRepository;
            this.genreRepository = genreRepository;
        }

        /// <summary>
        /// The handle to get requested Sales
        /// </summary>
        /// <param name="request">The request with filter and pagination params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested Sales</returns>
        public Task<PaginatedQueryResult<GetPaginatedSalesQueryResult>> Handle(GetPaginatedSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = saleRepository.GetPagedSales(request.StartDate, request.EndDate, request.Skip, request.Take);

            var result = sales.Select(x => new GetPaginatedSalesQueryResult(x.Id, x.DateSale, x.Albums
                .Select(y => new GetPaginatedSalesAlbumsQueryResult(y.Id, y.Price, GetCashback(x.DateSale, y.Genre, y.Price))).ToArray())).OrderByDescending(x => x.DateSale);

            return Task.FromResult(new PaginatedQueryResult<GetPaginatedSalesQueryResult>(result.ToArray(), saleRepository.Count));
        }

        private decimal GetCashback(DateTime dateSale, string genre, decimal price)
        {
            var genrePercent = genreRepository.GetPercent(genre, dateSale.DayOfWeek);
            return price * (genrePercent.Percent / 100);
        }
    }
}
