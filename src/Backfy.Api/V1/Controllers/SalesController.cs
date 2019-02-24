using Backfy.Sales.Command;
using Backfy.Sales.Command.Result;
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
    [ProducesResponseType(typeof(ProblemDetails), 400)]
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
        /// <param name="startDate">The start date range for date sale</param>
        /// <param name="endDate">The end date range for date sale</param>
        /// <param name="skip">The skip value</param>
        /// <param name="take">The take value</param>
        /// <returns>The requested sales</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPaginatedSalesQueryResult>), 200)]
        public async Task<IEnumerable<GetPaginatedSalesQueryResult>> Get(DateTime? startDate, DateTime? endDate, int skip, int take)
        {
            return await mediator.Send(new GetPaginatedSalesQuery(startDate, endDate, skip, take));
        }

        /// <summary>
        /// Get a single sale
        /// </summary>
        /// <param name="id">The request sale id</param>
        /// <returns>The requested sale</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetSaleQueryResult), 200)]
        public async Task<GetSaleQueryResult> Get(Guid id)
        {
            return await mediator.Send(new GetSaleQuery(id));
        }

        /// <summary>
        /// Places a new sale
        /// </summary>
        /// <param name="command" cref="AddSaleCommand">The new sale</param>
        /// <returns>Return the sale with cashback</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AddSaleCommandResult), 200)]
        public async Task<AddSaleCommandResult> Post([FromBody] AddSaleCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
