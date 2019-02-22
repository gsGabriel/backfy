namespace Backfy.Common.Infra.Pagination
{
    /// <summary>
    /// Class for base pagination implementation
    /// </summary>
    public class PaginationQuery
    {
        /// <summary>
        /// The actual page
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// The number of elements to take
        /// </summary>
        public int Take { get; set; }
    }
}
