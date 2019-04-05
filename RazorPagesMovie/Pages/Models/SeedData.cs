using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                );

                    Review Score1 = new Review 
                    {
                        Score = 1
                    };
                    context.Add(Score1);

                    Review Score2 = new Review 
                    {
                        Score = 2
                    };
                    context.Add(Score2);

                    Review Score3 = new Review 
                    {
                        Score = 3
                    };
                    context.Add(Score3);

                    Review Score4 = new Review 
                    {
                        Score = 4
                    };
                    context.Add(Score4);
                    
                    Review Score5 = new Review 
                    {
                        Score = 5
                    };
                    context.Add(Score5);

                Movie addReviewHarrySally = context.Movie.Where(m => m.Title == "When Harry Met Sally").First();
                addReviewHarrySally.Reviews.Add(Score4);

                Movie addReviewGhost = context.Movie.Where(m => m.Title == "Ghostbusters").First();
                addReviewGhost.Reviews.Add(Score3);
                addReviewGhost.Reviews.Add(Score2);

                Movie addReviewRio = context.Movie.Where(m => m.Title == "Rio Bravo").First();
                addReviewRio.Reviews.Add(Score5);
                addReviewRio.Reviews.Add(Score5);
                addReviewRio.Reviews.Add(Score4);

                context.SaveChanges();
            }
        }
    }
}