using Backfy.Common.Infra.Enums;
using System;

namespace Backfy.Albums.Repository.Models
{
    public class GenresPercent
    {
        public GenresPercent(Genres genre, DayOfWeek dayOfWeek, decimal percent)
        {
            Genre = genre;
            DayOfWeek = dayOfWeek;
            Percent = percent;
        }

        public Genres Genre { get; }
        public DayOfWeek DayOfWeek { get; }
        public decimal Percent { get; }
    }
}
