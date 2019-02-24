using Backfy.Albums.Query.Handler;
using Backfy.Common.Infra.Enums;
using Backfy.Common.Infra.Services.Interfaces;
using Backfy.Common.Infra.Services.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Backfy.Albums.Query.Tests
{
    public class GetPaginatedAlbumsQueryHandlerTest
    {
        [Fact]
        public async Task HasAPaginatedQueryResultOfGetAlbumPaginatedAsync()
        {
            var spotifyServiceMock = new Mock<ISpotifyService>();
            spotifyServiceMock.Setup(x => x.GetAlbumsAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new SpotifyPaging<SpotifyAlbum> { Items = new List<SpotifyAlbum> { new SpotifyAlbum { Id = "teste", Name = "Fake Teste", ReleaseDate = DateTime.Now.ToShortDateString(), TotalTracks = 10 } }, Total = 1 });

            var queryResult = await new GetPaginatedAlbumsQueryHandler(spotifyServiceMock.Object)
               .Handle(new GetPaginatedAlbumsQuery(null, 0, 10), new CancellationToken());

            Assert.NotNull(queryResult);
            Assert.NotEmpty(queryResult.Data);
        }

        [Fact]
        public async Task HasAEmptyPaginatedQueryResultOfGetAlbumPaginatedAsync()
        {
            var spotifyServiceMock = new Mock<ISpotifyService>();

            var queryResult = await new GetPaginatedAlbumsQueryHandler(spotifyServiceMock.Object)
               .Handle(new GetPaginatedAlbumsQuery(null, 0, 10), new CancellationToken());

            Assert.Null(queryResult);
        }
    }
}
