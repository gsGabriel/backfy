using Backfy.Sales.Repository.Interfaces;
using Backfy.Sales.Repository.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Backfy.Sales.Repository.Tests
{
    [UseAutofacTestFramework]
    public class SaleRepositoryTest
    {
        private readonly ISaleRepository saleRepository;

        public SaleRepositoryTest(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        [Fact]
        public void HasASpecifiedSale()
        {
            var saleExpected = new Sale(new List<SaleAlbum> { new SaleAlbum("teste", "classical", 10) });

            //Is not correct implementation of mock, but the moq framework doesn't has support for mock static fields
            //Save a expected sale
            saleRepository.SaveSale(saleExpected);

            var sale = saleRepository.GetSale(saleExpected.Id);
            Assert.Equal(saleExpected.Id, sale.Id);
            Assert.NotEmpty(sale.Albums);
        }

        [Fact]
        public void ThrowExceptionInGetASpecifiedSaleWithInvalidGuid()
        {
            Assert.Throws<InvalidOperationException>(() => saleRepository.GetSale(Guid.Empty));
        }

        [Fact]
        public void HasAListOfSaleByFilterAndPaging()
        {
            var salesExpecteds = new List<Sale>
            {
                new Sale(new List<SaleAlbum> { new SaleAlbum("teste", "classic", 60) }),
                new Sale(new List<SaleAlbum> { new SaleAlbum("teste 1", "rock", 50) }),
                new Sale(new List<SaleAlbum> { new SaleAlbum("teste 2", "mpb", 15) }),
                new Sale(new List<SaleAlbum> { new SaleAlbum("teste 3", "pop", 20) })
            };

            //Is not correct implementation of mock, but the moq framework doesn't has support for mock static fields
            //Save a expecteds sales
            salesExpecteds.ForEach(x => saleRepository.SaveSale(x));

            var sales = saleRepository.GetPagedSales(null, null, 0, 10);

            Assert.NotEmpty(sales);
            Assert.Equal(salesExpecteds.Count, sales.Count());
        }

        [Fact]
        public void CanSaveANewSaleWithAlbum()
        {
            var saleExpected = new Sale(new List<SaleAlbum> { new SaleAlbum("teste", "classic", 60) });

            var id = saleRepository.SaveSale(saleExpected);

            Assert.True(id != Guid.Empty);
        }

        [Fact]
        public void CanSaveANewSaleWithoutAlbum()
        {
            var saleExpected = new Sale(null);

            var id = saleRepository.SaveSale(saleExpected);

            Assert.True(id != Guid.Empty);
        }
    }
}
