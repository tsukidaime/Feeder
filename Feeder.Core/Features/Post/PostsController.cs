using Feeder.Features.Post.Queries.GetPostsByDateRange;
using Feeder.Features.Post.Queries.GetPostsByText;
using Feeder.Features.Post.Queries.GetTopUsedWords;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
    namespace Feeder.Core.Features.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Method retrieve posts by specific date range
        /// </summary>
        /// <param name="from">YYYY-MM-DD HH:mm:ss</param>
        /// <param name="to">YYYY-MM-DD HH:mm:ss</param>
        /// <returns></returns>
        [HttpGet("{from}/{to}")]
        public async Task<IActionResult> GetPostsByDateRange([FromRoute]DateTime from, [FromRoute] DateTime to)
        {
            var posts = await _mediator.Send(new GetPostsByDateRangeQuery(from, to));
            return Ok(posts);
        }

        /// <summary>
        /// Method retrieve posts by specific text
        /// </summary>
        /// <param name="text">text to search</param>
        /// <returns></returns>
        [HttpGet("{text}")]
        public async Task<IActionResult> GetPostsByText([FromRoute] string text)
        {
            var posts = await _mediator.Send(new GetPostsByTextQuery(text));
            return Ok(posts);
        }

        /// <summary>
        /// Method retrieve top 10 most used words in posts
        /// </summary>
        /// <returns></returns>
        [HttpGet("topten")]
        public async Task<IActionResult> GetTopUsedWords()
        {
            var posts = await _mediator.Send(new GetTopUsedWordsQuery());
            return Ok(posts);
        }
    }
}
