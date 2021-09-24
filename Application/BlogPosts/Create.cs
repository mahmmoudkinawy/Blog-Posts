﻿using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BlogPosts
{
    public class Create
    {
        public class Command : IRequest
        {
            public BlogPost BlogPost { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.BlogPosts.Add(request.BlogPost);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
