using Backfy.Albums.Repository.Interfaces;
using Backfy.Albums.Repository.Models;
using Backfy.Common.Infra.Enums;
using Backfy.Sales.Command.Handler;
using Backfy.Sales.Repository.Interfaces;
using Backfy.Sales.Repository.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Backfy.Sales.Command.Tests
{
    public class AddSaleCommandHandlerTest
    {
        [Fact]
        public async Task CanAddNewSaleAsync()
        {
            var saleRepositoryMock = new Mock<ISaleRepository>
            {
                CallBase = true,
            };
            saleRepositoryMock.Setup(x => x.SaveSale(It.IsAny<Sale>())).Returns(Guid.NewGuid());

            var genrePercentExpected = new GenresPercent(Genres.POP, DateTime.Now.DayOfWeek, 10);

            var genreRepositoryMock = new Mock<IGenreRepository>();
            genreRepositoryMock.Setup(x => x.GetPercent(It.IsAny<string>(), It.IsAny<DayOfWeek>())).Returns(genrePercentExpected);

            var commandResult = await new AddSaleCommandHandler(saleRepositoryMock.Object, genreRepositoryMock.Object)
                .Handle(new AddSaleCommand(new List<AddSaleAlbumCommand> { new AddSaleAlbumCommand("teste", "pop", 10) }), new CancellationToken());

            Assert.NotNull(commandResult);
            Assert.True(commandResult.Id != Guid.Empty);
            Assert.NotEmpty(commandResult.Albums);
        }

        [Fact]
        public async Task ThrowExceptionInAddNewSaleAsync()
        {
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var genreRepositoryMock = new Mock<IGenreRepository>();

            await Assert.ThrowsAsync<Exception>(() =>
                new AddSaleCommandHandler(saleRepositoryMock.Object, genreRepositoryMock.Object).Handle(new AddSaleCommand(null), new CancellationToken()));
        }
    }
}
