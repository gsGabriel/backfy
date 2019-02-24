using Backfy.Albums.Repository.Models;
using System;
using System.Collections.Generic;

namespace Backfy.Albums.Repository.Interfaces
{
    /// <summary>
    /// Repository for manipulate a genre model
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// Get all percentages of all genres
        /// </summary>
        /// <returns>The enumerable of association between genre and percentages</returns>
        IEnumerable<GenresPercent> GetAllPercents();

        /// <summary>
        /// Get a specified association between genre and percentage
        /// </summary>
        /// <param name="genre">The genre name</param>
        /// <param name="dayOfWeek">The day of week <see cref="DayOfWeek"/></param>
        /// <returns>The association between genre and percentage</returns>
        GenresPercent GetPercent(string genre, DayOfWeek dayOfWeek);
    }
}
