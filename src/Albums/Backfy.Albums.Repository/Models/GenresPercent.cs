using Backfy.Common.Infra.Enums;
using System;

namespace Backfy.Albums.Repository.Models
{
    /// <summary>
    /// The association between genres and percentages of cashback
    /// </summary>
    public class GenresPercent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenresPercent"/> class.
        /// </summary>
        /// <param name="genre">The genre enum <see cref="Genres"/></param>
        /// <param name="dayOfWeek">The day of week <see cref="DayOfWeek"/></param>
        /// <param name="percent">The percent of genre</param>
        public GenresPercent(Genres genre, DayOfWeek dayOfWeek, decimal percent)
        {
            Genre = genre;
            DayOfWeek = dayOfWeek;
            Percent = percent;
        }

        /// <summary>
        /// The genre enum <see cref="Genres"/>
        /// </summary>
        public Genres Genre { get; }

        /// <summary>
        /// The day of week <see cref="DayOfWeek"/>
        /// </summary>
        public DayOfWeek DayOfWeek { get; }

        /// <summary>
        /// The percent of genre
        /// </summary>
        public decimal Percent { get; }
    }
}
