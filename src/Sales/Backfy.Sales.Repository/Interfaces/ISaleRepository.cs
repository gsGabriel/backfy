using Backfy.Sales.Repository.Model;
using System;
using System.Collections.Generic;

namespace Backfy.Sales.Repository.Interfaces
{
    public interface ISaleRepository
    {
        Sale GetSale(Guid id);
        IEnumerable<Sale> GetPagedSales(DateTime? startDate, DateTime? endDate, int skip, int take);
        Guid SaveSale(Sale sale);
    }
}
