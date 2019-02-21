using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="id">The request album id</param>
        /// <returns>The requested album</returns>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
