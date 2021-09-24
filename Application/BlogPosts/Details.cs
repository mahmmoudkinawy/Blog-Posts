using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BlogPosts
{
    public class Details
    {
        public class Query : IRequest<Result<BlogPost>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<BlogPost>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<BlogPost>> Handle(Query request, CancellationToken cancellationToken)
            {
                var blogPost = await _context.BlogPosts.FindAsync(request.Id);

                return Result<BlogPost>.Success(blogPost);
            }
        }
    }
}
