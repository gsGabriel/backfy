using Backfy.Albums.Repository.Interfaces;
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
    public class GetPaginatedSalesQueryHandler : IRequestHandler<GetPaginatedSalesQuery, IEnumerable<GetPaginatedSalesQueryResult>>
    {
        private readonly ISaleRepository saleRepository;
        private readonly IGenreRepository genreRepository;

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
        public Task<IEnumerable<GetPaginatedSalesQueryResult>> Handle(GetPaginatedSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = saleRepository.GetPagedSales(request.StartDate, request.EndDate, request.Skip, request.Take);

            return Task.FromResult(sales.Select(x => new GetPaginatedSalesQueryResult(x.Id, x.DateSale, x.Albums
                .Select(y => new GetPaginatedSalesAlbumsQueryResult(y.Id, y.Price, GetCashback(x.DateSale, y.Genre, y.Price))).ToArray())));
        }

        private decimal GetCashback(DateTime dateSale, string genre, decimal price)
        {
            var genrePercent = genreRepository.GetPercent(genre, dateSale.DayOfWeek);
            return price * (genrePercent.Percent / 100);
        }
    }
}
