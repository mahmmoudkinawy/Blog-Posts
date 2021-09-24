using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BlogPosts
{
    public class List
    {
        public class Query : IRequest<List<BlogPost>>
        { }

        public class Handler : IRequestHandler<Query, List<BlogPost>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<BlogPost>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                return await _context.BlogPosts.ToListAsync();
            }
        }
    }
}
