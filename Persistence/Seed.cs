using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>()
                {
                    new AppUser()
                    {
                        Email = "lisa@gmail.com",
                        UserName = "lisa",
                        DisplayName = "Lisa"
                    },
                    new AppUser()
                    {
                        Email = "bob@gmail.com",
                        UserName = "bob",
                        DisplayName = "Bob"
                    }
                };

                foreach (var user in users)
                    await userManager.CreateAsync(user, "Pa$$w0rd");

            }

            if (context.BlogPosts.Any()) return;

            var blogPosts = new List<BlogPost>()
            {
                new BlogPost()
                {
                    Title = "This is title 1",
                    Content = "This is content 1, This is content 1, This is content 1,",
                    Summary = "This is summary 1",
                    Date = DateTime.Now
                },
                new BlogPost()
                {
                    Title = "This is title 2",
                    Content = "This is content 2, This is content 2, This is content 2,",
                    Summary = "This is summary 2",
                    Date = DateTime.Now
                },
                new BlogPost()
                {
                    Title = "This is title 3",
                    Content = "This is content 3, This is content 3, This is content 3,",
                    Summary = "This is summary 3",
                    Date = DateTime.Now
                },
                new BlogPost()
                {
                    Title = "This is title 4",
                    Content = "This is content 4, This is content 4, This is content 4,",
                    Summary = "This is summary 4",
                    Date = DateTime.Now
                },
            };

            await context.BlogPosts.AddRangeAsync(blogPosts);
            await context.SaveChangesAsync();
        }
    }
}
