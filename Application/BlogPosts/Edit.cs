using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BlogPosts
{
    public class Edit
    {
        public class Command : IRequest
        {
            public BlogPost BlogPost { get; set; }
        }

        public class Hanlder : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Hanlder(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var blogPost = await _context.BlogPosts.FindAsync(request.BlogPost.Id);

                _mapper.Map(request.BlogPost, blogPost);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }

    }
}
