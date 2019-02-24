using System.Collections.Generic;

namespace Backfy.Common.Infra.Pagination
{
    /// <summary>
    /// Wrapper for a paginated query results
    /// </summary>
    /// <typeparam name="T">The type of result <see cref="T"/></typeparam>
    public class PaginatedQueryResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T"/> class.
        /// </summary>
        /// <param name="data">The data collection of <see cref="T"/></param>
        /// <param name="total">The total of data</param>
        public PaginatedQueryResult(ICollection<T> data, int total)
        {
            Data = data;
            Total = total;
        }

        /// <summary>
        /// The data collection of <see cref="T"/>
        /// </summary>
        public ICollection<T> Data { get; }

        /// <summary>
        /// The total of data
        /// </summary>
        public int Total { get; }
    }
}
