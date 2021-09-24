using Application.BlogPosts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BlogPostsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BlogPostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogPost>>> GetBlogPosts()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(Guid id)
        {
            return Ok(await _mediator.Send(new Details.Query { Id = id }));
        }



    }
}
