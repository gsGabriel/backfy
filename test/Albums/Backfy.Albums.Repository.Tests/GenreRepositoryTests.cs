using Backfy.Albums.Repository.Interfaces;
using Backfy.Common.Infra.Enums;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Backfy.Albums.Repository.Tests
{
    [UseAutofacTestFramework]
    public class GenreRepositoryTests
    {
        private readonly IGenreRepository genreRepository;

        public GenreRepositoryTests(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        [Fact]
        public void HasPercentsInGenres()
        {
            var result = genreRepository.GetAllPercents();
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(Genres.CLASSICAL, DayOfWeek.Sunday)]
        [InlineData(Genres.MPB, DayOfWeek.Monday)]
        [InlineData(Genres.POP, DayOfWeek.Saturday)]
        [InlineData(Genres.ROCK, DayOfWeek.Wednesday)]
        public void HasPercentByGenreAndDayOfWeek(Genres genre, DayOfWeek dayOfWeek)
        {
            var result = genreRepository.GetPercent(genre.ToString(), dayOfWeek);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(Genres.NONE, DayOfWeek.Sunday)]
        [InlineData(Genres.NONE, DayOfWeek.Monday)]
        public void NotFoundPercentByGenreAndDayOfWeek(Genres genre, DayOfWeek dayOfWeek)
        {
            var result = genreRepository.GetPercent(genre.ToString(), dayOfWeek);
            Assert.Null(result);
        }
    }
}
