﻿using Backfy.Sales.Repository.Interfaces;
using Backfy.Sales.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backfy.Sales.Repository
{
    /// <inheritdoc />
    public class SaleRepository : ISaleRepository
    {
        private static List<Sale> Sales { get; set; }

        public int Count => Sales.Count();

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleRepository"/> class.
        /// </summary>
        public SaleRepository()
        {
            Sales = new List<Sale>();
        }

        /// <inheritdoc />
        public Sale GetSale(Guid id)
        {
            return Sales.Single(x => x.Id == id);
        }

        /// <inheritdoc />
        public IEnumerable<Sale> GetPagedSales(DateTime? startDate, DateTime? endDate, int skip, int take)
        {
            return Sales
                .Where(x => !startDate.HasValue || x.DateSale >= startDate.Value)
                .Where(x => !endDate.HasValue || x.DateSale <= endDate.Value)
                .OrderByDescending(x => x.DateSale)
                .Skip(skip)
                .Take(take)
                .ToArray();
        }

        /// <inheritdoc />
        public Guid SaveSale(Sale sale)
        {
            Sales.Add(sale);
            return sale.Id;
        }
    }
}
