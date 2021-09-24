using Domain;
using FluentValidation;

namespace Application.BlogPosts
{
    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
               .MinimumLength(5)
               .MaximumLength(100);
            RuleFor(x => x.Content).NotEmpty()
               .MinimumLength(50);
            RuleFor(x => x.Summary).NotEmpty()
                .MinimumLength(10)
                .MaximumLength(50);
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}
