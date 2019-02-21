using Backfy.Albums.Repository.Models;
using System;
using System.Collections.Generic;

namespace Backfy.Albums.Repository.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<GenresPercent> GetAllPercents();

        GenresPercent GetPercent(string genre, DayOfWeek dayOfWeek);
    }
}
