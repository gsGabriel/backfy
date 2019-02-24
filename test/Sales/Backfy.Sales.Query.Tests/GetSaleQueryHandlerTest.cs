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
    public class GetSaleQueryHandlerTest
    {
        [Fact]
        public async Task HasAGetSaleQueryResultAsync()
        {
            var saleExpected = new Sale(new List<SaleAlbum> { new SaleAlbum("teste", "classical", 10) });

            var saleRepositoryMock = new Mock<ISaleRepository>
            {
                CallBase = true,
            };
            saleRepositoryMock.Setup(x => x.GetSale(It.IsAny<Guid>())).Returns(saleExpected);

            var genrePercentExpected = new GenresPercent(Genres.POP, DateTime.Now.DayOfWeek, 10);

            var genreRepositoryMock = new Mock<IGenreRepository>
            {
                CallBase = true
            };
            genreRepositoryMock.Setup(x => x.GetPercent(It.IsAny<string>(), It.IsAny<DayOfWeek>())).Returns(genrePercentExpected);

            var queryResult = await new GetSaleQueryHandler(saleRepositoryMock.Object, genreRepositoryMock.Object).Handle(new GetSaleQuery(saleExpected.Id), new CancellationToken());

            Assert.NotNull(queryResult);
            Assert.Equal(saleExpected.Id, queryResult.Id);
            Assert.Equal(saleExpected.Albums.Count(), queryResult.Albums.Count());
        }

        [Fact]
        public async Task ThrowExceptionInGetSaleQueryHandlerWithInvalidGuid()
        {
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var genreRepositoryMock = new Mock<IGenreRepository>();

            await Assert.ThrowsAsync<Exception>(() => 
                new GetSaleQueryHandler(saleRepositoryMock.Object, genreRepositoryMock.Object).Handle(new GetSaleQuery(Guid.Empty), new CancellationToken()));
        }
    }
}
