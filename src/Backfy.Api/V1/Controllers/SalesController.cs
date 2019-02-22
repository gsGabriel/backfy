using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get a single sale
        /// </summary>
        /// <param name="id">The request sale id</param>
        /// <returns>The requested sale</returns>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
