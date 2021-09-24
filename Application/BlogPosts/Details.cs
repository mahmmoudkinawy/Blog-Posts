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
        public class Query : IRequest<BlogPost>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, BlogPost>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<BlogPost> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.BlogPosts.FindAsync(request.Id);
            }
        }
    }
}
