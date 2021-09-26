using Application.BlogPosts;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BlogPostsController : BaseApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<BlogPost>>> GetBlogPosts()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(BlogPost blogPost)
        {
            return HandleResult(await Mediator.Send(new Create.Command { BlogPost = blogPost }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(Guid id, BlogPost blogPost)
        {
            blogPost.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { BlogPost = blogPost }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}
