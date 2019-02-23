using Backfy.Albums.Repository.Interfaces;
using Backfy.Sales.Query.Result;
using Backfy.Sales.Repository.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Sales.Query.Handler
{
    /// <summary>
    /// QueryHandler to get a specified Sale
    /// </summary>
    public class GetSaleQueryHandler : IRequestHandler<GetSaleQuery, GetSaleQueryResult>
    {
        private readonly ISaleRepository saleRepository;
        private readonly IGenreRepository genreRepository;

        public GetSaleQueryHandler(ISaleRepository saleRepository, IGenreRepository genreRepository)
        {
            this.saleRepository = saleRepository;
            this.genreRepository = genreRepository;
        }

        /// <summary>
        /// The handle to get requested Sale
        /// </summary>
        /// <param name="request">The request with filter params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the requested Sale</returns>
        public Task<GetSaleQueryResult> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            var sale = saleRepository.GetSale(request.Id);

            return Task.FromResult(new GetSaleQueryResult(sale.Id, sale.DateSale, sale.Albums
                .Select(x => new GetSaleAlbumsQueryResult(x.Id, x.Price, GetCashback(sale.DateSale, x.Genre, x.Price))).ToArray()));
        }

        private decimal GetCashback(DateTime dateSale, string genre, decimal price)
        {
            var genrePercent = genreRepository.GetPercent(genre, dateSale.DayOfWeek);
            return price * (genrePercent.Percent / 100);
        }
    }
}
