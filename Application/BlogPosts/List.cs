using Application.Core;
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
        public class Query : IRequest<Result<List<BlogPost>>>
        { }

        public class Handler : IRequestHandler<Query, Result<List<BlogPost>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<BlogPost>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                return Result<List<BlogPost>>.Success(await _context.BlogPosts.ToListAsync());
            }
        }
    }
}
