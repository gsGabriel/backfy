using Backfy.Sales.Query;
using Backfy.Sales.Query.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backfy.Api.V1.Controllers
{
    /// <summary>
    /// Represents a RESTful service of sales.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator dependecy</param>
        public SalesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves a requested sales
        /// </summary>
        /// <returns>The requested sales</returns>
        [HttpGet]
        public async Task<IEnumerable<GetPaginatedSalesQueryResult>> Get(DateTime? startDate, DateTime? endDate, int skip, int take)
        {
            return await mediator.Send(new GetPaginatedSalesQuery(startDate, endDate, skip, take));
        }

        /// <summary>
        /// Get a single sale
        /// </summary>
        /// <param name="id">The request sale id</param>
        /// <returns>The requested sale</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<GetSaleQueryResult> Get(Guid id)
        {
            return await mediator.Send(new GetSaleQuery(id));
        }

        /// <summary>
        /// Places a new sale
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
