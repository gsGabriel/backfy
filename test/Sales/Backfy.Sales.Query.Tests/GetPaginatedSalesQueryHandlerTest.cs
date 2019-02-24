using Backfy.Albums.Repository.Interfaces;
using Backfy.Albums.Repository.Models;
using Backfy.Common.Infra.Enums;
using Backfy.Sales.Query.Handler;
using Backfy.Sales.Repository.Interfaces;
using Backfy.Sales.Repository.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Backfy.Sales.Query.Tests
{
    public class GetPaginatedSalesQueryHandlerTest
    {
        [Fact]
        public async Task HasAPaginatedQueryResultOfGetSalePaginatedAsync()
        {
            var salesExpected = new List<Sale> { new Sale(new List<SaleAlbum> { new SaleAlbum("teste", "classical", 10) }) };

            var saleRepositoryMock = new Mock<ISaleRepository>
            {
                CallBase = true,
            };
            saleRepositoryMock.Setup(x => x.GetPagedSales(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(salesExpected);

            var genrePercentExpected = new GenresPercent(Genres.POP, DateTime.Now.DayOfWeek, 10);

            var genreRepositoryMock = new Mock<IGenreRepository>
            {
                CallBase = true
            };
            genreRepositoryMock.Setup(x => x.GetPercent(It.IsAny<string>(), It.IsAny<DayOfWeek>())).Returns(genrePercentExpected);

            var queryResult = await new GetPaginatedSalesQueryHandler(saleRepositoryMock.Object, genreRepositoryMock.Object)
                .Handle(new GetPaginatedSalesQuery(null, null, 0, 10), new CancellationToken());

            Assert.NotNull(queryResult);
            Assert.NotEmpty(queryResult.Data);
        }

        [Fact]
        public async Task HasAEmptyPaginatedQueryResultOfGetSalePaginatedAsync()
        {
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var genreRepositoryMock = new Mock<IGenreRepository>();

            var queryResult = await new GetPaginatedSalesQueryHandler(saleRepositoryMock.Object, genreRepositoryMock.Object)
               .Handle(new GetPaginatedSalesQuery(null, null, 0, 10), new CancellationToken());

            Assert.NotNull(queryResult);
            Assert.Empty(queryResult.Data);
        }
    }
}
