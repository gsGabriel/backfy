using Backfy.Albums.Query.Handler;
using Backfy.Common.Infra.Services.Interfaces;
using Backfy.Common.Infra.Services.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Backfy.Albums.Query.Tests
{
    public class GetAlbumQueryHandlerTest
    {
        [Fact]
        public async Task HasAGetSaleQueryResultAsync()
        {
            var spotifyAlbum = new SpotifyAlbum { Id = "teste", Name = "Fake Teste", ReleaseDate = DateTime.Now.ToShortDateString(), TotalTracks = 10 };

            var spotifyServiceMock = new Mock<ISpotifyService>();
            spotifyServiceMock.Setup(x => x.GetAlbumAsync(It.IsAny<string>())).ReturnsAsync(spotifyAlbum);

            var queryResult = await new GetAlbumQueryHandler(spotifyServiceMock.Object).Handle(new GetAlbumQuery(spotifyAlbum.Id), new CancellationToken());

            Assert.NotNull(queryResult);
            Assert.Equal(spotifyAlbum.Id, queryResult.Id);
            Assert.True(queryResult.Price > 0);
        }

        [Fact]
        public async Task ThrowExceptionInGetAlbumQueryHandlerWithInvalidI()
        {
            var spotifyServiceMock = new Mock<ISpotifyService>();

            await Assert.ThrowsAsync<Exception>(() => 
                new GetAlbumQueryHandler(spotifyServiceMock.Object).Handle(new GetAlbumQuery(string.Empty), new CancellationToken()));
        }
    }
}
