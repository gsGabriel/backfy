using Backfy.Sales.Repository.Model;
using System;
using System.Collections.Generic;

namespace Backfy.Sales.Repository.Interfaces
{
    /// <summary>
    /// Repository for manipulate a sale model
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Get a specified sale
        /// </summary>
        /// <param name="id">The identifier of sale</param>
        /// <returns>The sale model</returns>
        Sale GetSale(Guid id);

        /// <summary>
        /// Get a paged sales
        /// </summary>
        /// <param name="startDate">The start date range for date sale</param>
        /// <param name="endDate">The end date range for date sale</param>
        /// <param name="skip">The skip value</param>
        /// <param name="take">The take value</param>
        /// <returns>The paged sales</returns>
        IEnumerable<Sale> GetPagedSales(DateTime? startDate, DateTime? endDate, int skip, int take);

        /// <summary>
        /// Save a new sale
        /// </summary>
        /// <param name="sale">New sale model</param>
        /// <returns>The sale identifier</returns>
        Guid SaveSale(Sale sale);
    }
}
