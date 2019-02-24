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

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSaleQueryHandler"/> class.
        /// </summary>
        /// <param name="saleRepository"></param>
        /// <param name="genreRepository"></param>
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
            BusinessValidation(request);

            var sale = saleRepository.GetSale(request.Id);

            return Task.FromResult(new GetSaleQueryResult(sale.Id, sale.DateSale, sale.Albums
                .Select(x => new GetSaleAlbumsQueryResult(x.Id, x.Price, GetCashback(sale.DateSale, x.Genre, x.Price))).ToArray()));
        }

        private void BusinessValidation(GetSaleQuery request)
        {
            if(request.Id == Guid.Empty)
            {
                throw new Exception("Id inválido");
            }
        }

        private decimal GetCashback(DateTime dateSale, string genre, decimal price)
        {
            var genrePercent = genreRepository.GetPercent(genre, dateSale.DayOfWeek);
            return price * (genrePercent.Percent / 100);
        }
    }
}
