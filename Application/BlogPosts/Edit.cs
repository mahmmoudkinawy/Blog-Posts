using Application.Core;
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
        public class Command : IRequest<Result<Unit>>
        {
            public BlogPost BlogPost { get; set; }
        }

        public class Hanlder : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Hanlder(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var blogPost = await _context.BlogPosts.FindAsync(request.BlogPost.Id);

                if (blogPost == null)
                    return null;

                _mapper.Map(request.BlogPost, blogPost);

                var result =  await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to update blog post");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}
