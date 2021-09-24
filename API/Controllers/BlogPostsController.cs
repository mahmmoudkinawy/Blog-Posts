using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BlogPostsController : BaseApiController
    {
        private readonly DataContext _context;

        public BlogPostsController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<BlogPost>>> GetBlogPosts()
        {
            return Ok(await _context.BlogPosts.ToListAsync());
        }

    }
}
