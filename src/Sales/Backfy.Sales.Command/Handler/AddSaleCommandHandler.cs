using Backfy.Albums.Repository.Interfaces;
using Backfy.Sales.Command.Result;
using Backfy.Sales.Repository.Interfaces;
using Backfy.Sales.Repository.Model;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backfy.Sales.Command.Handler
{
    /// <summary>
    /// QueryHandler to add a sale
    /// </summary>
    public class AddSaleCommandHandler : IRequestHandler<AddSaleCommand, AddSaleCommandResult>
    {
        private readonly ISaleRepository saleRepository;
        private readonly IGenreRepository genreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddSaleCommandHandler"/> class.
        /// </summary>
        /// <param name="saleRepository"></param>
        /// <param name="genreRepository"></param>
        public AddSaleCommandHandler(ISaleRepository saleRepository, IGenreRepository genreRepository)
        {
            this.saleRepository = saleRepository;
            this.genreRepository = genreRepository;
        }

        /// <summary>
        /// The handle to add a Sale
        /// </summary>
        /// <param name="request">The request with filter params</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task with the result of Sale</returns>
        public Task<AddSaleCommandResult> Handle(AddSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale(request.Albums.Select(x => new SaleAlbum(x.Id, x.Genre, x.Price)));
            var idSale = saleRepository.SaveSale(sale);

            return Task.FromResult(new AddSaleCommandResult(sale.Id, sale.DateSale, sale.Albums
                .Select(y => new AddSaleAlbumsCommandResult(y.Id, y.Price, GetCashback(sale.DateSale, y.Genre, y.Price))).ToArray()));
        }

        private decimal GetCashback(DateTime dateSale, string genre, decimal price)
        {
            var genrePercent = genreRepository.GetPercent(genre, dateSale.DayOfWeek);
            return price * (genrePercent.Percent / 100);
        }
    }
}
