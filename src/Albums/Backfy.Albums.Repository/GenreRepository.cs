using Backfy.Albums.Repository.Interfaces;
using Backfy.Albums.Repository.Models;
using Backfy.Common.Infra.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backfy.Albums.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IEnumerable<GenresPercent> genresPercents;

        public GenreRepository()
        {
            genresPercents = new List<GenresPercent>
            {
                new GenresPercent(Genres.CLASSICAL, DayOfWeek.Sunday, 35),
                new GenresPercent(Genres.CLASSICAL, DayOfWeek.Monday, 3),
                new GenresPercent(Genres.CLASSICAL, DayOfWeek.Tuesday, 5),
                new GenresPercent(Genres.CLASSICAL, DayOfWeek.Wednesday, 8),
                new GenresPercent(Genres.CLASSICAL, DayOfWeek.Thursday, 13),
                new GenresPercent(Genres.CLASSICAL, DayOfWeek.Friday, 18),
                new GenresPercent(Genres.CLASSICAL, DayOfWeek.Saturday, 25),
                new GenresPercent(Genres.MPB, DayOfWeek.Sunday, 30),
                new GenresPercent(Genres.MPB, DayOfWeek.Monday, 5),
                new GenresPercent(Genres.MPB, DayOfWeek.Tuesday, 10),
                new GenresPercent(Genres.MPB, DayOfWeek.Wednesday, 15),
                new GenresPercent(Genres.MPB, DayOfWeek.Thursday, 20),
                new GenresPercent(Genres.MPB, DayOfWeek.Friday, 25),
                new GenresPercent(Genres.MPB, DayOfWeek.Saturday, 30),
                new GenresPercent(Genres.POP, DayOfWeek.Sunday, 25),
                new GenresPercent(Genres.POP, DayOfWeek.Monday, 7),
                new GenresPercent(Genres.POP, DayOfWeek.Tuesday, 6),
                new GenresPercent(Genres.POP, DayOfWeek.Wednesday, 2),
                new GenresPercent(Genres.POP, DayOfWeek.Thursday, 10),
                new GenresPercent(Genres.POP, DayOfWeek.Friday, 15),
                new GenresPercent(Genres.POP, DayOfWeek.Saturday, 20),
                new GenresPercent(Genres.ROCK, DayOfWeek.Sunday, 40),
                new GenresPercent(Genres.ROCK, DayOfWeek.Monday, 10),
                new GenresPercent(Genres.ROCK, DayOfWeek.Tuesday, 15),
                new GenresPercent(Genres.ROCK, DayOfWeek.Wednesday, 15),
                new GenresPercent(Genres.ROCK, DayOfWeek.Thursday, 15),
                new GenresPercent(Genres.ROCK, DayOfWeek.Friday, 20),
                new GenresPercent(Genres.ROCK, DayOfWeek.Saturday, 40)
            };
        }

        public IEnumerable<GenresPercent> GetAllPercents()
        {
            return genresPercents.ToList();
        }

        public GenresPercent GetPercent(string genre, DayOfWeek dayOfWeek)
        {
            return genresPercents.SingleOrDefault(x => x.Genre.ToString().Contains(genre) && x.DayOfWeek == dayOfWeek);
        }
    }
}
