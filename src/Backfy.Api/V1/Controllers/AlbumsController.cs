﻿using Backfy.Albums.Query;
using Backfy.Albums.Query.Result;
using Backfy.Common.Infra.Pagination;
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
    [ProducesResponseType(typeof(ProblemDetails), 400)]
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
        /// <param name="genre">The genre name</param>
        /// <param name="skip">The actual page</param>
        /// <param name="take">The number of elements to take</param>
        /// <returns>The requested albums</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedQueryResult<GetPaginatedAlbumsQueryResult>), 200)]
        public async Task<PaginatedQueryResult<GetPaginatedAlbumsQueryResult>> Get(string genre, int skip, int take)
        {
            return await mediator.Send(new GetPaginatedAlbumsQuery(genre, skip, take));
        }

        /// <summary>
        /// Get a single album
        /// </summary>
        /// <param name="id">The request album identifier</param>
        /// <returns>The requested album</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetAlbumQueryResult), 200)]
        public async Task<GetAlbumQueryResult> Get(string id)
        {
            return await mediator.Send(new GetAlbumQuery(id));
        }
    }
}
