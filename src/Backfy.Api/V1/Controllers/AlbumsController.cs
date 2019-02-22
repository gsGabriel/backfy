using Backfy.Albums.Query;
using Backfy.Albums.Query.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backfy.Api.V1.Controllers
{
    /// <summary>
    /// Represents a RESTful service of albums
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AlbumsController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator dependecy</param>
        public AlbumsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves a requested albums
        /// </summary>
        /// <returns>The requested albums</returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get a single album
        /// </summary>
        /// <param name="id">The request album identifier</param>
        /// <returns>The requested album</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAlbumQueryResult>> Get(string id)
        {
            return await mediator.Send(new GetAlbumQuery(id));
        }
    }
}
